using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    public abstract class CacheList<T> : CacheSingleton<T> where T : new()
    {
        public CacheList(string pathToCache) : base(pathToCache)
        {
        }

        public override ReadOnlyCollection<string> Keys
        {
            get
            {
                List<string> keys = new List<string>();
                Parallel.ForEach(_Library.Keys, Constants.ParallelOptions,
                    current =>
                    {
                        string actualKey = current.Split('|')[0];
                        if (!keys.Contains(actualKey)) keys.Add(actualKey);
                    });

                return new ReadOnlyCollection<string>(keys);
            }
        }

        public override void Add(string key, T value)
        {
            base.Add(key + "|" + Guid.NewGuid(), value);
        }

        public int GetTotalHitCount(string key)
        {
            return GetAll(key).Count();
        }
    }
}