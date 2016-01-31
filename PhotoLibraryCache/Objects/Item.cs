using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Item
    {
        public Properties Properties { get; set; }

        public Exif Exif { get; set; }
    }
}