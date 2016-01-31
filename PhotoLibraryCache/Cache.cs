using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PhotoLibrary.Cache
{
    public abstract class Cache<T>
    {
        private static PersistentDictionary<string, T> _LibraryCache;

        public static ReadOnlyCollection<string> Keys { get { return new ReadOnlyCollection<string>(_LibraryCache.Keys.ToList()); } }

        #region Get/Set

        public static T Get(string key)
        {
            return _LibraryCache[key];
        }

        public static T Get(string location, int index)
        {
            T ans;
            if (location == null)
            {
                ans = _LibraryCache.ElementAt(index).Value;
            }
            else {
                ans = _LibraryCache.Where(k => k.Key.StartsWith(location)).ElementAt(index).Value;
            }

            return ans;
        }

        public static void Set(string key, T value)
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
                ans = Keys.Where(k => k.StartsWith(location, StringComparison.OrdinalIgnoreCase)).ElementAt(index);
            }

            return ans;
        }

        public static Tuple<string, bool> GetPreviousCacheEntry(string location, string key)
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

            return new Tuple<string, bool>(ans, getIndex == 0);
        }

        public static Tuple<string, bool> GetNextCacheEntry(string path, string imageKey)
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

            return new Tuple<string, bool>(ans, getIndex == CountValues(path) - 1);
        }

        #endregion Get/Set

        #region Add/Remove

        public static void Add(string key, T value)
        {
            if (_LibraryCache.ContainsKey(key))
            {
                _LibraryCache[key] = (T)value;
            }
            else
            {
                _LibraryCache.Add(key, (T)value);
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

        public static int CountValuesWhere(Func<T, bool> predicate)
        {
            return _LibraryCache.Values.Count(predicate);
        }

        #endregion Counting the cache

        public static void Flush()
        {
            _LibraryCache.Flush();
        }

        public static void Clear()
        {
            if (PersistentDictionaryFile.Exists(_LibraryCache.DatabasePath))
            {
                PersistentDictionaryFile.DeleteFiles(_LibraryCache.DatabasePath);
            }
        }
    }
}