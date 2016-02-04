using System;

namespace PhotoLibrary.Reference.Objects
{
    public class ChangeProgressedEventArgs : EventArgs
    {
        private readonly int _Progress;
        public int Progress { get { return _Progress; } }

        public ChangeProgressedEventArgs(int percentage)
        {
            _Progress = percentage;
        }
    }
}