using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace PhotoLibrary
{
    /// <summary>
    /// Contains the methods for loading the photos into the application
    /// </summary>
    public static class PhotoWork
    {
        public static Settings Settings { get; set; }

        /// <summary>
        /// Loads the pics details into memory
        /// </summary>
        /// <param name="fullpath">The path in which the photos are located</param>
        public static void LoadDirectory(BackgroundWorker worker, string initialDirectory)
        {
            // Initializes the objects used
            Settings = new Settings(initialDirectory);
            if (PersistentDictionaryFile.Exists(Constants.CacheFullPath))
            {
                PersistentDictionaryFile.DeleteFiles(Constants.CacheFullPath);
            }

            //
            // Listing the medias
            List<string> medias = GetListMediasInInitialDirectory();
            NerdStats.NumberOfMediasLoaded = medias.Count;

            // For each media found
            AddToLibrary(worker, medias);

            // Lists ignored files
            Settings.Ignored = Directory.EnumerateFiles(Settings.GetDirectory, "*", SearchOption.AllDirectories).
                 Where(file => !Constants.AllowedExtensionsImages().Any(file.ToUpperInvariant().EndsWith)).
                 Where(file => !Constants.AllowedExtensionsVideos().Any(file.ToUpperInvariant().EndsWith)).
                 ToList();
        }

        /// <summary>
        /// Loads the available library
        /// </summary>
        public static void LoadLibrary()
        {
            Settings = new Settings(null);

            using (FileStream file = File.OpenRead(Constants.BaseFullPath))
            {
                var deserializer = new DataContractSerializer(typeof(Settings));
                using (var reader = new XmlTextReader(file))
                {
                    Settings = deserializer.ReadObject(reader) as Settings;
                }
            }
        }

        public static int[] CheckForUpdatesOnLibrary()
        {
            int[] ans = new int[2];

            // We got the library loaded, now we should check its integrity
            List<string> mediasOnDisk = GetListMediasInInitialDirectory().ConvertAll(s => s.Replace(Settings.GetDirectory, ""));
            //// Lists the medias missing in the library (aka New content)
            List<string> newContent = mediasOnDisk.Except(LibraryCache.Keys).ToList().ConvertAll(s => s.Insert(0, Settings.GetDirectory));
            ans[0] = newContent.Count;
            AddToLibrary(null, newContent);
            //// Lists the medias missing in the initial directory (aka Missing content)
            List<string> missingContent = mediasOnDisk.Except(LibraryCache.Keys).ToList();
            ans[1] = missingContent.Count;
            RemoveFromLibrary(missingContent);

            return ans;
        }

        /// <summary>
        /// Lists the medias existing in the initial directory
        /// </summary>
        /// <returns>The list of all medias in the initial directory</returns>
        private static List<string> GetListMediasInInitialDirectory()
        {
            return Directory.EnumerateFiles(Settings.GetDirectory, "*", SearchOption.AllDirectories).
                Where(file =>
                Constants.AllowedExtensionsImages().Any(file.ToUpperInvariant().EndsWith) ||
                Constants.AllowedExtensionsVideos().Any(file.ToUpperInvariant().EndsWith)).
                ToList();
        }

        /// <summary>
        /// Add medias to the cache
        /// </summary>
        /// <param name="worker">a background worker to report progress to</param>
        /// <param name="medias">the list of medias to add to the library</param>
        private static void AddToLibrary(BackgroundWorker worker, List<string> medias)
        {
            Parallel.ForEach(medias, Constants.ParallelOptions,
                current =>
                {
                    // Add it to the library
                    LibraryCache.Add(current.Replace(Settings.GetDirectory, ""), new CacheObject());

                    // Report progress made
                    if (worker != null)
                    {
                        lock (new object()) { worker.ReportProgress(100 * LibraryCache.CountValues(null) / NerdStats.NumberOfMediasLoaded); };
                    }
                });
        }

        /// <summary>
        /// Remove medias to the cache
        /// </summary>
        /// <param name="medias">the list of medias to remove from the library</param>
        private static void RemoveFromLibrary(List<string> medias)
        {
            Parallel.ForEach(medias, Constants.ParallelOptions,
                current =>
                {
                    // Remove it to the library
                    LibraryCache.Remove(current.Replace(Settings.GetDirectory, ""));
                });
        }

        /// <summary>
        /// Saves the library to its own files<br/>
        /// The file then contains the initialDir and the list of files
        /// </summary>
        public static void SaveLibrary()
        {
            // Delete the existing library file
            if (File.Exists(Constants.BaseFullPath)) File.Delete(Constants.BaseFullPath);

            // Serialize and saves the library
            using (FileStream file = File.Create(Constants.BaseFullPath))
            {
                var serializer = new DataContractSerializer(typeof(Settings));
                using (var writer = new XmlTextWriter(file, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, Settings);
                    writer.Flush();
                }
            }

            // Dispose of the cache
            LibraryCache.Flush();
        }

        #region Thumbnail generation and Image manipulation

        /// <summary>
        /// Generate a thumbnail for a specified file
        /// </summary>
        /// <param name="background">The background color that item will have</param>
        /// <param name="pathToFile">The complete path to the file to open</param>
        /// <returns>The generated thumbnail</returns>
        public static CacheObject GenerateCacheObject(Color background, String pathToFile)
        {
            CacheObject ans = new CacheObject();
            int targetWidth = 128, targetHeight = 128;

            Image temp = null;
            /// Generate the thumbnail depending on the type of file
            if (pathToFile != null)
            {
                if (Constants.AllowedExtensionsImages().Any(pathToFile.ToUpperInvariant().EndsWith))
                {
                    temp = GenerateThumbnailPhoto(pathToFile);
                }
                else
                {
                    temp = GenerateThumbnailVideo(pathToFile);
                }
            }

            Image target = new Bitmap(1, 1);
            (target as Bitmap).SetPixel(0, 0, background);
            target = new Bitmap(target, targetWidth, targetHeight);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.Clear(background);
                int x = (targetWidth - temp.Width) / 2;
                int y = (targetHeight - temp.Height) / 2;
                g.DrawImage(temp, x, y);
            }

            ans.Thumbnail = target;

            return ans;
        }

        /// <summary>
        /// Generate a thumbnail for a specified file
        /// </summary>
        /// <param name="pathToFile">The complete path to the file to open</param>
        ///
        /// <returns>The generated thumbnail</returns>
        private static Image GenerateThumbnailPhoto(String pathToFile)
        {
            using (FileStream fs = new FileStream(pathToFile, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.FromStream(fs, true, false))
                {
                    return ScaleImage(image, 128, 128);
                }
            }
        }

        /// <summary>
        /// Generate a thumbnail for a specified file
        /// </summary>
        /// <param name="pathToFile">The complete path to the file to open</param>
        ///
        /// <returns>The generated thumbnail</returns>
        private static Image GenerateThumbnailVideo(String pathToFile)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                FFMpegConverter ffmpeg = new FFMpegConverter();
                ffmpeg.GetVideoThumbnail(pathToFile, memStream);
                using (Image image = Image.FromStream(memStream, true, false))
                {
                    return ScaleImage(image, 128, 128);
                }
            }
        }

        private static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        #endregion Thumbnail generation and Image manipulation

        public static CacheExif GetExifFromImage(string pathToFile)
        {
            CacheExif ans = new CacheExif();

            using (FileStream fs = new FileStream(pathToFile, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.FromStream(fs, false, false))
                {
                    Parallel.ForEach(image.PropertyItems, Constants.ParallelOptions,
                        current =>
                        {
                            var previousPriority = Thread.CurrentThread.Priority;
                            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

                            ans.SetValue(Constants.ExifData[current.Id], current.Value);

                            //Reset previous priority of the TPL Thread
                            Thread.CurrentThread.Priority = previousPriority;
                        });
                }
            }
            ans.HasBeenSet = true;

            return ans;
        }
    }
}