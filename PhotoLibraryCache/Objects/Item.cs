using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Item
    {
        public Properties Properties { get; set; }

        public Exif Exif { get; set; }

        public override int GetHashCode()
        {
            return Properties.GetHashCode() ^ Exif.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Item))
                return false;

            return Equals((Item)obj);
        }

        public bool Equals(Item other)
        {
            if (Properties != other.Properties || Exif != other.Exif)
                return false;

            return true;
        }

        public static bool operator ==(Item item1, Item item2)
        {
            return item1.Equals(item2);
        }

        public static bool operator !=(Item item1, Item item2)
        {
            return !item1.Equals(item2);
        }
    }
}