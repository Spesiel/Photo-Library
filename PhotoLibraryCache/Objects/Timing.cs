using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Timing
    {
        public DateTime Date { get; set; }
        public TimeSpan Timer { get; set; }

        public override int GetHashCode()
        {
            return Date.GetHashCode() ^ Timer.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Timing))
                return false;

            return Equals((Timing)obj);
        }

        public bool Equals(Timing other)
        {
            if (Date != other.Date || Timer != other.Timer)
                return false;

            return true;
        }

        public static bool operator ==(Timing timing1, Timing timing2)
        {
            return timing1.Equals(timing2);
        }

        public static bool operator !=(Timing timing1, Timing timing2)
        {
            return !timing1.Equals(timing2);
        }
    }
}