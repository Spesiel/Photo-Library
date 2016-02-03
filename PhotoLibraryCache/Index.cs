using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using PhotoLibrary.Reference.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoLibrary.Cache
{
    public static class Index
    {
        //FIXME Change the path
        private static PersistentDictionary<Guid, string> _Library = new PersistentDictionary<Guid, string>(Constants.CacheFullPath + "Index");

        public static PersistentDictionary<Guid, string> Library { get { return _Library; } }

        public static IEnumerable<Guid> Get(string path)
        {
            return Library.Where(i => i.Value.Equals(path)).Select(i => i.Key);
        }

        public static string FromGuid(Guid key)
        {
            return Library[key] + Literals.GuidSeparator + key.ToString();
        }

        public static Guid Add(string path)
        {
            Guid guid = Guid.NewGuid();
            Library.Add(guid, path);
            return guid;
        }

        public static bool Remove(Guid key)
        {
            bool ans = true;
            Library.Where(i => i.Key == key).AsParallel().ForAll(i => ans &= Library.Remove(i.Key));
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

            // Dispose of the current library
            Library.Dispose();
            _Library = null;

            // Create a brand new one
            PersistentDictionaryFile.DeleteFiles(path);
            _Library = new PersistentDictionary<Guid, string>(path);
        }

        #endregion Flush & Clear
    }
}