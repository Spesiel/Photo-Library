namespace PhotoLibrary.Cache
{
    public static class Libraries
    {
        private static Items _Items = new Items();
        private static Timers _Timers = new Timers();
        private static Persons _Persons = new Persons();

        public static Items Items { get { return _Items; } }
        public static Timers Timers { get { return _Timers; } }
        public static Persons Persons { get { return _Persons; } }

        public static void Remove(string key)
        {
            Items.Remove(key);
            Timers.RemoveAll(key);
            Persons.RemoveAll(key);
        }

        public static void Flush()
        {
            Items.Flush();
            Timers.Flush();
            Persons.Flush();
        }

        public static void Clear()
        {
            Items.Clear();
            Timers.Clear();
            Persons.Clear();
        }
    }
}