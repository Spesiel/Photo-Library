using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class Preview : Form
    {
        private string DirectoryFilter { get; set; }
        private string Key { get; set; }

        public Preview()
        {
            InitializeComponent();
        }

        public Preview(string filter, string imageKey)
        {
            DirectoryFilter = filter;
            Key = imageKey;
            InitializeComponent();

            label.Text = Text = Key;
            picture.Load(PhotoWork.Settings.GetFile(Key));

            // Sets the navigation
            int index = LibraryCache.GetIndex(DirectoryFilter, Key);
            if (index == 0)
            {
                pic_previous.Visible = false;
            }
            if (index == LibraryCache.CountValues(DirectoryFilter) - 1)
            {
                pic_next.Visible = false;
            }
        }

        private void pic_previous_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, bool> newKey = LibraryCache.GetPreviousCacheEntry(DirectoryFilter, Key);
            Key = newKey.Key;
            // We have reached the first pic
            if (newKey.Value)
            {
                pic_previous.Visible = false;
            }
            else
            {
                pic_previous.Visible = true;
                pic_next.Visible = true;
            }

            label.Text = Text = Key;
            picture.Load(PhotoWork.Settings.GetFile(Key));
        }

        private void pic_next_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, bool> newKey = LibraryCache.GetNextCacheEntry(DirectoryFilter, Key);
            Key = newKey.Key;
            // We have reached the last pic
            if (newKey.Value)
            {
                pic_next.Visible = false;
            }
            else
            {
                pic_previous.Visible = true;
                pic_next.Visible = true;
            }

            label.Text = Text = Key;
            picture.Load(PhotoWork.Settings.GetFile(Key));
        }
    }
}