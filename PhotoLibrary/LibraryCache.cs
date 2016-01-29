using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoLibrary
{
    public static class LibraryCache
    {
        private static PersistentDictionary<string, CacheObject> _LibraryCache = new PersistentDictionary<string, CacheObject>(Constants.CacheFullPath);

        public static ReadOnlyCollection<string> Keys { get { return new ReadOnlyCollection<string>(_LibraryCache.Keys.ToList()); } }

        #region Get/Set

        public static CacheObject Get(string key)
        {
            return _LibraryCache[key];
        }

        public static CacheObject Get(string location, int index)
        {
            CacheObject ans;
            if (location == null)
            {
                ans = _LibraryCache.ElementAt(index).Value;
            }
            else {
                ans = _LibraryCache.Where(k => k.Key.StartsWith(location)).ElementAt(index).Value;
            }

            return ans;
        }

        public static void Set(string key, CacheObject value)
        {
            if (_LibraryCache.ContainsKey(key))
            {
                _LibraryCache[key] = value;
            }
            else
            {
                _LibraryCache.Add(key, value);
            }
        }

        public static int GetIndex(string location, string key)
        {
            int ans = 0;
            if (location == null)
            {
                ans = Keys.IndexOf(key);
            }
            else
            {
                ans = Keys.Where(k => k.StartsWith(location, StringComparison.OrdinalIgnoreCase)).ToList().IndexOf(key);
            }

            return ans;
        }

        public static string GetKey(string location, int index)
        {
            string ans = null;
            if (location == null)
            {
                ans = Keys.ElementAt(index);
            }
            else {
                ans = Keys.Where(k => k.StartsWith(location)).ElementAt(index);
            }

            return ans;
        }

        public static KeyValuePair<string, bool> GetPreviousCacheEntry(string location, string key)
        {
            string ans = string.Empty;

            int getIndex = GetIndex(location, key);
            if (getIndex > 0)
            {
                getIndex--;
            }

            if (location == null)
            {
                ans = Keys[getIndex];
            }
            else
            {
                ans = Keys.Where(k => k.StartsWith(location, StringComparison.OrdinalIgnoreCase)).ToList()[getIndex];
            }

            return new KeyValuePair<string, bool>(ans, getIndex == 0);
        }

        public static KeyValuePair<string, bool> GetNextCacheEntry(string path, string imageKey)
        {
            string ans = string.Empty;

            int getIndex = GetIndex(path, imageKey);
            if (getIndex < CountValues(path) - 1)
            {
                getIndex++;
            }

            if (path == null)
            {
                ans = Keys[getIndex];
            }
            else
            {
                ans = Keys.Where(k => k.StartsWith(path, StringComparison.OrdinalIgnoreCase)).ToList()[getIndex];
            }

            return new KeyValuePair<string, bool>(ans, getIndex == CountValues(path) - 1);
        }

        #endregion Get/Set

        #region Add/Remove

        public static void Add(string key, CacheObject? value)
        {
            if (_LibraryCache.ContainsKey(key))
            {
                _LibraryCache[key] = (CacheObject)value;
            }
            else
            {
                _LibraryCache.Add(key, (CacheObject)value);
            }
        }

        public static bool Remove(string key)
        {
            return _LibraryCache.Remove(key);
        }

        #endregion Add/Remove

        #region Counting the cache

        public static int Count { get { return _LibraryCache.Count; } }

        public static int CountValues(string location)
        {
            int ans = 0;
            if (location == null)
            {
                ans = _LibraryCache.Count;
            }
            else {
                ans = _LibraryCache.Count(item => item.Key.StartsWith(location));
            }

            return ans;
        }

        public static int CountValuesWhere(Func<CacheObject, bool> predicate)
        {
            return _LibraryCache.Values.Count(predicate);
        }

        #endregion Counting the cache

        #region Tags: GetAll/FindBy

        public static IEnumerable<string> AllTags
        {
            get
            {
                List<string> ans = new List<string>();
                Parallel.ForEach(_LibraryCache.Values.ToList(), Constants.ParallelOptions,
                    current =>
                    {
                        ans.AddRange(current.Tags);
                    });

                return ans.Distinct();
            }
        }

        public static IEnumerable<CacheObject> FindByTag(string tag)
        {
            return _LibraryCache.Values.Where(v => v.Tags.Contains(tag));
        }

        public static IEnumerable<CacheObject> FindByTags(IList<string> tags)
        {
            return _LibraryCache.Values.Where(v => v.Tags.Any(t => tags.Contains(t)));
        }

        #endregion Tags: GetAll/FindBy

        public static void Flush()
        {
            _LibraryCache.Flush();
        }

        #region Background work

        public static void BackgroundFetchForThumbnails(BackgroundWorker worker, Color background)
        {
            // For each media
            Parallel.ForEach(_LibraryCache.Where(t => t.Value.Thumbnail == null), Constants.ParallelOptions,
                current =>
                {
                    if (current.Value.Thumbnail == null)
                    {
                        var previousPriority = Thread.CurrentThread.Priority;
                        Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

                        string currentFile = PhotoWork.Settings.GetFile(current.Key);

                        // Add it to the library
                        Set(current.Key, PhotoWork.GenerateCacheObject(background, currentFile));

                        // Report progress made
                        lock (new object())
                        {
                            worker.ReportProgress(100 * (CountValuesWhere(v => v.Thumbnail == null)) /
                                Count);
                        };

                        //Reset previous priority of the TPL Thread
                        Thread.CurrentThread.Priority = previousPriority;
                    }
                });
        }

        public static void BackgroundFetchForExif(BackgroundWorker worker)
        {
            // For each media
            Parallel.ForEach(_LibraryCache.Where(t => false.Equals(t.Value.Exif.HasBeenSet)), Constants.ParallelOptions,
                current =>
                {
                    if (current.Value.Thumbnail == null)
                    {
                        var previousPriority = Thread.CurrentThread.Priority;
                        Thread.CurrentThread.Priority = ThreadPriority.Lowest;

                        string currentFile = PhotoWork.Settings.GetFile(current.Key);

                        // Add it to the library
                        CacheObject co = LibraryCache.Get(current.Key);
                        //FIXME Do this elsewhere
                        co.Exif = PhotoWork.GetExifFromImage(currentFile);
                        Set(current.Key, co);

                        // Report progress made
                        lock (new object())
                        {
                            worker.ReportProgress(100 * (CountValuesWhere(v => false.Equals(v.Exif.HasBeenSet))) /
                                Count);
                        };

                        //Reset previous priority of the TPL Thread
                        Thread.CurrentThread.Priority = previousPriority;
                    }
                });
        }

        #endregion Background work
    }
}