namespace PhotoLibrary.Reference.Objects
{
    public static class Change
    {
        public delegate void ChangeProgressChangedEventHandler(ChangeProgressedEventArgs e);

        public static event ChangeProgressChangedEventHandler Progressed;

        public delegate void ChangeCompletedEventHandler(ChangeCompletedEventArgs e);

        public static event ChangeCompletedEventHandler Completed;

        public static void Report(int percentage)
        {
            Progressed(new ChangeProgressedEventArgs(percentage));
            if (percentage >= 100) Completed(new ChangeCompletedEventArgs());
        }
    }
}