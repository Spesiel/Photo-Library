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
            return Libraries.Items.GetKey(location, index);
        }

        public static int GetIndex(string location, string key)
        {
            return Libraries.Items.GetIndex(location, key);
        }

        public static Image GetThumbnail(string key)
        {
            return Libraries.Items.Get(key).Properties.Thumbnail;
        }

        #endregion Straightforward Getters

        public static Tuple<string, bool> GetPreviousCacheEntry(string location, string key)
        {
            return Libraries.Items.GetPreviousCacheEntry(location, key);
        }

        public static Tuple<string, bool> GetNextCacheEntry(string location, string key)
        {
            return Libraries.Items.GetNextCacheEntry(location, key);
        }

        public static int CountValues(string location)
        {
            return Libraries.Items.CountValues(location);
        }

        public static int CountValuesWhereThumbnailIsPresent()
        {
            return Libraries.Items.CountValuesWhere(v => v.Properties.Thumbnail != null);
        }

        public static int CountValuesWhereExifIsPresent()
        {
            return Libraries.Items.CountValuesWhere(v => v.Exif.HasBeenSet);
        }
    }
}