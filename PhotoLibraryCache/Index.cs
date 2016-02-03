using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using System;
using System.Threading.Tasks;

namespace PhotoLibrary.Cache
{
    internal static class Index
    {
        //FIXME Change the path
        private static PersistentDictionary<Guid, string> _Library = new PersistentDictionary<Guid, string>(Constants.CacheFullPath + "Index");

        public static PersistentDictionary<Guid, string> Library { get { return _Library; } }

        public static Guid Add(string key)
        {
            Guid ans = Guid.NewGuid();

            Library.Add(ans, key);

            return ans;
        }

        public static bool Remove(string key)
        {
            bool ans = true;

            Parallel.ForEach(Library.Where(i => i.Value.Equals(key)), Constants.ParallelOptions,
                current =>
                {
                    Library.Remove(current.Key);
                });

            return ans;
        }

        #region Flush & Clear

        public static void Flush()
        {
            Library.Flush();
        }

        public static void Clear()
        {
            string path = Library.DatabasePath;

            Library.Dispose();
            _Library = null;

            PersistentDictionaryFile.DeleteFiles(path);
            _Library = new PersistentDictionary<Guid, string>(path);
        }

        #endregion Flush & Clear
    }
}