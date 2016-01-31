using PhotoLibrary.Cache;
using System;
using System.Drawing;

namespace PhotoLibrary
{
    public static class Navigation
    {
        #region Straightforward Getters

        public static string GetKey(string location, int index)
        {
            return Libraries.LibraryObjects.GetKey(location, index);
        }

        public static int GetIndex(string location, string key)
        {
            return Libraries.LibraryObjects.GetIndex(location, key);
        }

        public static Image GetThumbnail(string key)
        {
            return Libraries.LibraryObjects.Get(key).Properties.Thumbnail;
        }

        #endregion Straightforward Getters

        public static Tuple<string, bool> GetPreviousCacheEntry(string location, string key)
        {
            return Libraries.LibraryObjects.GetPreviousCacheEntry(location, key);
        }

        public static Tuple<string, bool> GetNextCacheEntry(string location, string key)
        {
            return Libraries.LibraryObjects.GetNextCacheEntry(location, key);
        }

        public static int CountValues(string location)
        {
            return Libraries.LibraryObjects.CountValues(location);
        }

        public static int CountValuesWhereThumbnailIsPresent()
        {
            return Libraries.LibraryObjects.CountValuesWhere(v => v.Properties.Thumbnail != null);
        }

        public static int CountValuesWhereExifIsPresent()
        {
            return Libraries.LibraryObjects.CountValuesWhere(v => v.Exif.HasBeenSet);
        }
    }
}