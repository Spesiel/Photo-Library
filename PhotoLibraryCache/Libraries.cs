using PhotoLibrary.Reference;

namespace PhotoLibrary.Cache
{
    public static class Libraries
    {
        private static LibraryObjects _LibraryObjects = new LibraryObjects();

        public static LibraryObjects LibraryObjects { get { return _LibraryObjects; } }

        public static void Remove(string key)
        {
            LibraryObjects.Remove(key);
        }

        public static void Flush()
        {
            LibraryObjects.Flush();
        }

        public static void Clear()
        {
            LibraryObjects.Clear();
        }
    }
}