using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Item
    {
        private string _Thumbnail { get; set; }
        public Exif Exif { get; set; }

        [IgnoreDataMember]
        public Image Thumbnail
        {
            get
            {
                if (!string.IsNullOrEmpty(_Thumbnail))
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(_Thumbnail)))
                    {
                        return Image.FromStream(ms);
                    }
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        value.Save(ms, ImageFormat.Jpeg);
                        _Thumbnail = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public override int GetHashCode()
        {
            return _Thumbnail.GetHashCode() ^ Exif.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Item))
                return false;

            return Equals((Item)obj);
        }

        public bool Equals(Item other)
        {
            if (_Thumbnail != other._Thumbnail || Exif != other.Exif)
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