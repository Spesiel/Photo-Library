using System;
using System.Runtime.Serialization;

namespace PhotoLibrary.Cache
{
    [Serializable]
    public struct CacheObject
    {
        public Properties Properties { get; set; }

        public Exif Exif { get; set; }
    }
}