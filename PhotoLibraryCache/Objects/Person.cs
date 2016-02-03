using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Person
    {
        public string DisplayName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}