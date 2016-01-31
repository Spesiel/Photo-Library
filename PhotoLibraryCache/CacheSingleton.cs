using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public abstract class CacheSingleton<T>
    {
        internal PersistentDictionary<string, T> _Library;

        public virtual ReadOnlyCollection<string> Keys { get { return new ReadOnlyCollection<string>(_Library.Keys.ToList()); } }

        public CacheSingleton(string pathToCache)
        {
            _Library = new PersistentDictionary<string, T>(pathToCache);
        }

        #region Get/Set

        public T Get(string key)
        {
            return _Library[key];
        }

        public IEnumerable<T> GetAll(string key)
        {
            return _Library.Where(lib => lib.Key.StartsWith(key)).Select(lib => lib.Value);
        }

        public T Get(string location, int index)
        {
            T ans;
            if (location == null)
            {
                ans = _Library.ElementAt(index).Value;
            }
            else {
                ans = _Library.Where(k => k.Key.StartsWith(location)).ElementAt(index).Value;
            }

            return ans;
        }

        public void Set(string key, T value)
        {
            if (_Library.ContainsKey(key))
            {
                _Library[key] = value;
            }
            else
            {
                _Library.Add(key, value);
            }
        }

        public int GetIndex(string location, string key)
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

        public string GetKey(string location, int index)
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

        public Tuple<string, bool> GetPreviousCacheEntry(string location, string key)
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

        public Tuple<string, bool> GetNextCacheEntry(string path, string imageKey)
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

        public virtual void Add(string key, T value)
        {
            if (_Library.ContainsKey(key))
            {
                _Library[key] = (T)value;
            }
            else
            {
                _Library.Add(key, (T)value);
            }
        }

        internal virtual bool Remove(string key)
        {
            return _Library.Remove(key);
        }

        public void RemoveAll(string key)
        {
            Parallel.ForEach(_Library.Where(lib => lib.Key.StartsWith(key)), Constants.ParallelOptions,
                current =>
                {
                    _Library.Remove(current);
                });
        }

        #endregion Add/Remove

        #region Counting the cache

        public int Count { get { return _Library.Count; } }

        public int CountValues(string location)
        {
            int ans = 0;
            if (location == null)
            {
                ans = _Library.Count;
            }
            else {
                ans = _Library.Count(item => item.Key.StartsWith(location));
            }

            return ans;
        }

        public int CountValuesWhere(Func<T, bool> predicate)
        {
            return _Library.Values.Count(predicate);
        }

        #endregion Counting the cache

        public void Flush()
        {
            _Library.Flush();
        }

        public void Clear()
        {
            string path = _Library.DatabasePath;

            _Library.Dispose();
            _Library = null;

            PersistentDictionaryFile.DeleteFiles(path);
            _Library = new PersistentDictionary<string, T>(path);
        }
    }
}