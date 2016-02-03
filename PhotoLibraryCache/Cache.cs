using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public abstract class Cache<T> : IDisposable
    {
        internal PersistentDictionary<Guid, T> _Library;

        public IEnumerable<Tuple<string, T, Guid>> Library
        {
            get
            {
                return Index.Library.Where(i => _Library.ContainsKey(i.Key)).OrderBy(i => i.Value).Select(a => Tuple.Create(a.Value, _Library[a.Key], a.Key));
            }
        }

        public ReadOnlyCollection<string> Keys
        {
            get
            {
                return new ReadOnlyCollection<string>(Index.Library.Where(i => _Library.ContainsKey(i.Key)).Select(i => i.Value).OrderBy(i => i).ToList());
            }
        }

        protected Cache(string pathToCache)
        {
            _Library = new PersistentDictionary<Guid, T>(pathToCache);
        }

        #region Get/Set

        public T Get(string key)
        {
            return _Library[Index.Library.Where(i => i.Value.Equals(key)).Select(i => i.Key).Single()];
        }

        public T Get(string location, int index)
        {
            T ans;
            if (location == null)
            {
                ans = Library.ElementAt(index).Item2;
            }
            else {
                ans = Library.Where(i => i.Item1.StartsWith(location)).ElementAt(index).Item2;
            }

            return ans;
        }

        public IEnumerable<T> GetAll(string key)
        {
            return Library.Where(i => i.Item1.StartsWith(key)).Select(i => i.Item2);
        }

        public void Set(string key, T value)
        {
            if (Index.Library.ContainsValue(key))
            {
                _Library[Index.Library.Where(i => i.Value.Equals(key)).Single().Key] = value;
            }
            else
            {
                Add(key, value);
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
            if (Index.Library.ContainsValue(key))
            {
                _Library[Library.Where(i => i.Item1.Equals(key)).Single().Item3] = value;
            }
            else
            {
                _Library.Add(Index.Add(key), value);
            }
        }

        internal bool Remove(string key)
        {
            return _Library.Remove(Library.Where(i => i.Item1.StartsWith(key, StringComparison.OrdinalIgnoreCase)).Single().Item3);
        }

        public void RemoveAll(string key)
        {
            Parallel.ForEach(Library.Where(i => i.Item1.StartsWith(key, StringComparison.OrdinalIgnoreCase)),
                Constants.ParallelOptions,
                current =>
                {
                    _Library.Remove(current.Item3);
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
                ans = _Library.Count();
            }
            else {
                ans = Keys.Count(i => i.StartsWith(location));
            }

            return ans;
        }

        public int CountValuesWhere(Func<T, bool> predicate)
        {
            return _Library.Values.Count(predicate);
        }

        public int CountHits(string key)
        {
            return GetAll(key).Count();
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
            _Library = new PersistentDictionary<Guid, T>(path);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _Library.Dispose();
                }

                _Library = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}