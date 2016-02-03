using Microsoft.Isam.Esent.Collections.Generic;
using PhotoLibrary.Reference;
using PhotoLibrary.Reference.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoLibrary.Cache
{
    internal static class Index
    {
        //FIXME Change the path
        private static PersistentDictionary<Guid, string> _Library = new PersistentDictionary<Guid, string>(Constants.CacheFullPath + "Index");

        public static PersistentDictionary<Guid, string> Library { get { return _Library; } }

        public static KeyValuePair<Guid, string> ToKeyValuePair(string key)
        {
            string[] split = key.Split(Literals.GuidSeparator[0]);
            KeyValuePair<Guid, string> kvp = new KeyValuePair<Guid, string>(Guid.Parse(split[1]), split[0]);
            if (Library.Contains(kvp)) return kvp;
            return new KeyValuePair<Guid, string>();
        }

        public static string FromGuid(Guid key, string value)
        {
            return value + Literals.GuidSeparator + key.ToString();
        }

        public static string FromGuid(KeyValuePair<Guid, string> kvp)
        {
            return FromGuid(kvp.Key, kvp.Value);
        }

        public static string FromGuid(Guid key)
        {
            return FromGuid(key, Library[key]);
        }

        public static string FromGuid(string value)
        {
            return FromGuid(Library.Where(i => i.Value.Equals(value)).Single());
        }

        public static string Add(string key)
        {
            Guid guid = Guid.NewGuid();
            Library.Add(guid, key);
            return FromGuid(guid, key);
        }

        public static bool Remove(string key)
        {
            bool ans = true;
            Library.Where(i => i.Value == key).AsParallel().ForAll(i => ans &= Library.Remove(i.Key));
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