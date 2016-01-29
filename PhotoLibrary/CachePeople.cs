using Microsoft.Isam.Esent.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoLibrary
{
    [Serializable]
    public struct CachePeople
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        #region Overrides

        public override bool Equals(object obj)
        {
            return Equals((CachePeople)obj);
        }

        public bool Equals(CachePeople obj)
        {
            return Firstname.Equals(obj.Firstname) && Lastname.Equals(obj.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        #endregion Overrides
    }

    public static class LibraryPeople
    {
        private static PersistentDictionary<Guid, CachePeople> _LibraryPeople = new PersistentDictionary<Guid, CachePeople>(Constants.CacheFullPath + "People");

        public static IEnumerable<CachePeople> Library { get { return _LibraryPeople.Values.Distinct(); } }

        public static CachePeople Get(Guid key)
        {
            return _LibraryPeople[key];
        }

        public static void Add(CachePeople value)
        {
            if (!_LibraryPeople.ContainsValue(value))
            {
                _LibraryPeople.Add(Guid.NewGuid(), value);
            }
        }

        public static bool Remove(Guid key)
        {
            return _LibraryPeople.Remove(key);
        }

        public static void Flush()
        {
            _LibraryPeople.Flush();
        }
    }
}