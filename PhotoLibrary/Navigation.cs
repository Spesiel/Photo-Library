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
            return LibraryCache.GetKey(location, index);
        }

        public static int GetIndex(string location, string key)
        {
            return LibraryCache.GetIndex(location, key);
        }

        public static Image GetThumbnail(string key)
        {
            return LibraryCache.Get(key).Thumbnail;
        }

        #endregion Straightforward Getters

        public static Tuple<string, bool> GetPreviousCacheEntry(string location, string key)
        {
            return LibraryCache.GetPreviousCacheEntry(location, key);
        }

        public static Tuple<string, bool> GetNextCacheEntry(string location, string key)
        {
            return LibraryCache.GetNextCacheEntry(location, key);
        }

        public static int CountValues(string location)
        {
            return LibraryCache.CountValues(location);
        }

        public static int CountValuesWhereThumbnailIsAbsent()
        {
            return LibraryCache.CountValuesWhere(v => v.Thumbnail != null);
        }
    }
}