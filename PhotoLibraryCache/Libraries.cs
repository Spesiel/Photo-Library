namespace PhotoLibrary.Cache
{
    public static class Libraries
    {
        private static Items _Items = new Items();
        private static Persons _Persons = new Persons();
        private static Tags _Tags = new Tags();
        private static Timings _Timers = new Timings();

        public static Items Items { get { return _Items; } }
        public static Persons Persons { get { return _Persons; } }
        public static Timings Timers { get { return _Timers; } }
        public static Tags Tags { get { return _Tags; } }

        public static void Remove(string key)
        {
            Items.Remove(key);
            Persons.Remove(key);
            Tags.Remove(key);
            Timers.Remove(key);

            Index.Remove(key);
        }

        public static void Flush()
        {
            Items.Flush();
            Persons.Flush();
            Tags.Flush();
            Timers.Flush();

            Index.Flush();
        }

        public static void Clear()
        {
            Items.Clear();
            Persons.Clear();
            Tags.Clear();
            Timers.Clear();

            Index.Clear();
        }
    }
}