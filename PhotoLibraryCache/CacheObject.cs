using System;
using System.Runtime.Serialization;

namespace PhotoLibrary.Cache
{
    [Serializable]
    public struct CacheObject
    {
        public Properties Properties { get; set; }

        private string _exif { get; set; }

        [IgnoreDataMember]
        public Exif Exif
        {
            get
            {
                if (_exif != null)
                {
                    return Exif.FromXml(_exif);
                }

                return new Exif();
            }

            set
            {
                _exif = Exif.ToXml(value);
            }
        }
    }
}