//TODO CacheTimer
using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public static class TimespanLibrary
    {
        private static PersistentDictionary<string, TimeSpan> _library = new PersistentDictionary<string, TimeSpan>(Constants.CacheFullPath + "Span");

        public static ReadOnlyCollection<string> Keys
        {
            get
            {
                List<string> keys = new List<string>();
                Parallel.ForEach(_library.Keys, Constants.ParallelOptions,
                    current =>
                    {
                        string actualKey = current.Split('|')[0];
                        if (!keys.Contains(actualKey)) keys.Add(actualKey);
                    });

                return new ReadOnlyCollection<string>(keys);
            }
        }

        public static void Flush()
        {
            _library.Flush();
        }

        public static IEnumerable<TimeSpan> Get(string key)
        {
            return _library.Where(lib => lib.Key.StartsWith(key)).Select(lib => lib.Value);
        }

        public static TimeSpan GetTotalTime(string key)
        {
            return Get(key).Aggregate(new TimeSpan(0), (p, v) => p.Add(v));
        }

        public static int GetTotalHitCount(string key)
        {
            return Get(key).Count();
        }

        public static void Add(string key, TimeSpan value)
        {
            if (value.TotalSeconds >= Math.PI)
            {
                _library.Add(key + "|" + Guid.NewGuid(), value);
            }
        }

        public static void Remove(string key)
        {
            Parallel.ForEach(_library.Where(lib => lib.Key.StartsWith(key)), Constants.ParallelOptions,
                current =>
                {
                    _library.Remove(current);
                });
        }
    }
}