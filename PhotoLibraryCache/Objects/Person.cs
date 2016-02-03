//TODO Objects.Person

using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}