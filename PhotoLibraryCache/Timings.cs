using PhotoLibrary.Cache.Objects;
using PhotoLibrary.Reference;
using System;
using System.Linq;

namespace PhotoLibrary.Cache
{
    public class Timings : Cache<Timing>
    {
        //FIXME Change the path
        public Timings() : base(Constants.CacheFullPath + "Timers")
        {
        }

        public TimeSpan GetTotalTime(string key)
        {
            return GetAll(key).Aggregate(new TimeSpan(0), (p, v) => p.Add(v.Timer));
        }

        public override void Add(string key, Timing value)
        {
            if (value.Timer.TotalSeconds >= Math.PI)
            {
                base.Add(key, value);
            }
        }
    }
}