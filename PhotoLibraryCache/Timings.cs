using PhotoLibrary.Reference;
using System;
using System.Linq;

namespace PhotoLibrary.Cache
{
    public class Timings : CacheList<TimeSpan>
    {
        //FIXME Change the path
        public Timings() : base(Constants.CacheFullPath + "Timers")
        {
        }

        public TimeSpan GetTotalTime(string key)
        {
            return GetAll(key).Aggregate(new TimeSpan(0), (p, v) => p.Add(v));
        }

        public override void Add(string key, TimeSpan value)
        {
            if (value.TotalSeconds >= Math.PI)
            {
                base.Add(key, value);
            }
        }
    }
}