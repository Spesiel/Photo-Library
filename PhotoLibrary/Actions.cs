using NReco.VideoConverter;
using PhotoLibrary.Cache;
using PhotoLibrary.Reference;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoLibrary
{
    public static class Actions
    {
        public static void GenerateThumbnail(Color background, string file)
        {
            if (Libraries.LibraryObjects.Get(file).Thumbnail == null)
            {
                // Add it to the library
                Libraries.LibraryObjects.Set(file,
                    GenerateCacheObjectThumbnail(background, AtRuntime.Settings.GetFile(file)));
            }
        }

        #region Background work

        public static void BackgroundFetchForThumbnails(BackgroundWorker worker, Color background)
        {
            // For each media
            Parallel.ForEach(Libraries.LibraryObjects.Keys.Where(t => Libraries.LibraryObjects.Get(t).Thumbnail == null), Constants.ParallelOptions,
                current =>
                {
                    // Set TPL Thread priority, saving the old one
                    var previousPriority = Thread.CurrentThread.Priority;
                    Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

                    GenerateThumbnail(background, current);

                    //Reset previous priority of the TPL Thread
                    Thread.CurrentThread.Priority = previousPriority;

                    // Report progress made
                    lock (new object())
                    {
                        worker.ReportProgress(100 * Navigation.CountValuesWhereThumbnailIsPresent() /
                            Navigation.CountValues(null));
                    };
                });
        }

        public static void BackgroundFetchForExif(BackgroundWorker worker)
        {
            // For each media
            Parallel.ForEach(Libraries.LibraryObjects.Keys.Where(t => false.Equals(Libraries.LibraryObjects.Get(t).Exif.HasBeenSet)), Constants.ParallelOptions,
                current =>
                {
                    // Set TPL Thread priority, saving the old one
                    var previousPriority = Thread.CurrentThread.Priority;
                    Thread.CurrentThread.Priority = ThreadPriority.Lowest;

                    if (!Libraries.LibraryObjects.Get(current).Exif.HasBeenSet)
                    {
                        string currentFile = AtRuntime.Settings.GetFile(current);

                        // Add it to the library
                        CacheObject co = Libraries.LibraryObjects.Get(current);
                        co.Exif = GetExifFromImage(currentFile);
                        Libraries.LibraryObjects.Set(current, co);
                    }

                    //Reset previous priority of the TPL Thread
                    Thread.CurrentThread.Priority = previousPriority;

                    // Report progress made
                    lock (new object())
                    {
                        worker.ReportProgress(100 * Navigation.CountValuesWhereExifIsPresent() /
                            Navigation.CountValues(null));
                    };
                });
        }

        #endregion Background work

        #region Thumbnail generation and Image manipulation

        /// <summary>
        /// Generate a thumbnail for a specified file
        /// </summary>
        /// <param name="background">The background color that item will have</param>
        /// <param name="pathToFile">The complete path to the file to open</param>
        /// <returns>The generated thumbnail</returns>
        public static CacheObject GenerateCacheObjectThumbnail(Color background, String pathToFile)
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

                            if (Constants.ExifData.ContainsKey(current.Id))
                            {
                                ans.SetValue(Constants.ExifData[current.Id], current.Value);
                            }

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