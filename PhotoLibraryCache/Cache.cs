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

        public ReadOnlyCollection<string> Keys
        {
            get
            {
                return new ReadOnlyCollection<string>(
                    Index.Library.Where(i => _Library.Keys.Any(k => k.Equals(i.Key))).
                    Select(i => i.Value).
                    Distinct().OrderBy(o => o).ToList());
            }
        }

        private ReadOnlyDictionary<string, Guid> Pairs
        {
            get
            {
                return new ReadOnlyDictionary<string, Guid>(
                    Index.Library.Where(i => _Library.Keys.Any(k => k.Equals(i.Key))).
                    Distinct().OrderBy(o => o.Value).ToDictionary(p => p.Value, p => p.Key));
            }
        }

        protected Cache(string pathToCache)
        {
            _Library = new PersistentDictionary<Guid, T>(pathToCache);
        }

        #region Get/Set

        public T Get(Guid key)
        {
            return _Library[key];
        }

        public T Get(string path)
        {
            return _Library[Index.Get(path).Single()];
        }

        public T Get(string location, int index)
        {
            T ans;
            if (location == null)
            {
                ans = _Library[Pairs.ElementAt(index).Value];
            }
            else {
                ans = _Library[Pairs.
                    Where(i => i.Key.StartsWith(location, StringComparison.OrdinalIgnoreCase)).
                    ElementAt(index).Value];
            }

            return ans;
        }

        public IEnumerable<T> GetAll(string path)
        {
            return _Library.Where(l => Index.Get(path).Any(g => g.Equals(l.Key))).Select(i => i.Value);
        }

        public void Set(string path, T value)
        {
            if (Index.Library.ContainsValue(path))
            {
                _Library[Index.Get(path).Single()] = value;
            }
            else
            {
                Add(path, value);
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

        public virtual void Add(string path, T value)
        {
            _Library.Add(Index.Add(path), value);
        }

        internal bool Remove(Guid key)
        {
            return _Library.Remove(key);
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