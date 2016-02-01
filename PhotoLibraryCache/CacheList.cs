using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference.Globalization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PhotoLibrary.Cache
{
    public abstract class CacheList<T> : CacheSingleton<T>
    {
        protected CacheList(string pathToCache) : base(pathToCache)
        {
        }

        public override ReadOnlyCollection<string> Keys
        {
            get
            {
                List<string> keys = new List<string>();

                base.Keys.AsParallel().ForAll(current =>
                {
                    keys.Add(current.Split(new[] { Literals.GuidSeparator }, StringSplitOptions.RemoveEmptyEntries)[0]);
                });

                return new ReadOnlyCollection<string>(keys.Distinct().ToList());
            }
        }

        public override void Add(string key, T value)
        {
            base.Add(key + Literals.GuidSeparator + Guid.NewGuid(), value);
        }

        public int GetTotalHitCount(string key)
        {
            return GetAll(key).Count();
        }
    }
}