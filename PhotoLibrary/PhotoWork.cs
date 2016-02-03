using PhotoLibrary.Cache;
using PhotoLibrary.Cache.Objects;
using PhotoLibrary.Reference;
using PhotoLibrary.Reference.Objects;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PhotoLibrary
{
    /// <summary>
    /// Contains the methods for loading the photos into the application
    /// </summary>
    public static class PhotoWork
    {
        /// <summary>
        /// Loads the pics details into memory
        /// </summary>
        /// <param name="fullpath">The path in which the photos are located</param>
        public static void LoadDirectory(BackgroundWorker worker, string initialDirectory)
        {
            // Initializes the objects used
            AtRuntime.Settings = new Settings(initialDirectory);
            Libraries.Clear();

            // Listing the medias
            List<string> medias = GetListMediasInInitialDirectory();
            NerdStats.NumberOfMediasLoaded = medias.Count;

            // For each media found
            AddToLibrary(worker, medias);

            // Lists ignored files
            AtRuntime.Settings.SetIgnored(Directory.EnumerateFiles(AtRuntime.Settings.GetDirectory, "*", SearchOption.AllDirectories).
                 Where(file => !Constants.AllowedExtensionsImages().Any(file.ToUpperInvariant().EndsWith)).
                 Where(file => !Constants.AllowedExtensionsVideos().Any(file.ToUpperInvariant().EndsWith)).
                 ToList());
        }

        /// <summary>
        /// Loads the available library
        /// </summary>
        public static void LoadLibrary()
        {
            AtRuntime.Settings = new Settings(null);

            using (FileStream file = File.OpenRead(Constants.BaseFullPath))
            {
                var deserializer = new DataContractSerializer(typeof(Settings));
                using (var reader = new XmlTextReader(file))
                {
                    AtRuntime.Settings = deserializer.ReadObject(reader) as Settings;
                }
            }
        }

        public static int[] CheckForUpdatesOnLibrary()
        {
            int[] ans = new int[2];

            // We got the library loaded, now we should check its integrity
            List<string> mediasOnDisk = GetListMediasInInitialDirectory().ConvertAll(s => s.Replace(AtRuntime.Settings.GetDirectory, ""));
            //// Lists the medias missing in the library (aka New content)
            List<string> newContent = mediasOnDisk.Except(Libraries.Items.Keys).ToList().ConvertAll(s => s.Insert(0, AtRuntime.Settings.GetDirectory));
            ans[0] = newContent.Count;
            AddToLibrary(null, newContent);
            //// Lists the medias missing in the initial directory (aka Missing content)
            List<string> missingContent = mediasOnDisk.Except(Libraries.Items.Keys).ToList();
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
            return Directory.EnumerateFiles(AtRuntime.Settings.GetDirectory, "*", SearchOption.AllDirectories).
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
                    Libraries.Items.Add(current.Replace(AtRuntime.Settings.GetDirectory, ""), new Item());

                    // Report progress made
                    if (worker != null)
                    {
                        lock (new object()) { worker.ReportProgress(100 * Libraries.Items.CountValues(null) / NerdStats.NumberOfMediasLoaded); };
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
                    Libraries.Remove(current.Replace(AtRuntime.Settings.GetDirectory, ""));
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
                    serializer.WriteObject(writer, AtRuntime.Settings);
                    writer.Flush();
                }
            }

            // Dispose of the cache
            Libraries.Flush();
        }
    }
}