namespace PhotoLibrary.Cache
{
    public static class Libraries
    {
        private static Items _Items = new Items();
        private static Timings _Timers = new Timings();
        private static Persons _Persons = new Persons();
        private static Tags _Tags = new Tags();

        public static Items Items { get { return _Items; } }
        public static Timings Timers { get { return _Timers; } }
        public static Persons Persons { get { return _Persons; } }
        public static Tags Tags { get { return _Tags; } }

        public static void Remove(string key)
        {
            Items.Remove(key);
            Timers.RemoveAll(key);
            Persons.RemoveAll(key);
            Tags.RemoveAll(key);
        }

        public static void Flush()
        {
            Items.Flush();
            Timers.Flush();
            Persons.Flush();
            Tags.Flush();
        }

        public static void Clear()
        {
            Items.Clear();
            Timers.Clear();
            Persons.Clear();
            Tags.Clear();
        }
    }
}