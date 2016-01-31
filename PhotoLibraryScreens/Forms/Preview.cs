using PhotoLibrary.Reference;
using System;
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
            picture.Load(AtRuntime.Settings.GetFile(Key));

            // Sets the navigation
            int index = Navigation.GetIndex(DirectoryFilter, Key);
            if (index == 0)
            {
                pic_previous.Visible = false;
            }
            if (index == Navigation.CountValues(DirectoryFilter) - 1)
            {
                pic_next.Visible = false;
            }
        }

        private void pic_previous_Click(object sender, EventArgs e)
        {
            Tuple<string, bool> newKey = Navigation.GetPreviousCacheEntry(DirectoryFilter, Key);
            Key = newKey.Item1;
            // We have reached the first pic
            if (newKey.Item2)
            {
                pic_previous.Visible = false;
            }
            else
            {
                pic_previous.Visible = true;
                pic_next.Visible = true;
            }

            label.Text = Text = Key;
            picture.Load(AtRuntime.Settings.GetFile(Key));
        }

        private void pic_next_Click(object sender, EventArgs e)
        {
            Tuple<string, bool> newKey = Navigation.GetNextCacheEntry(DirectoryFilter, Key);
            Key = newKey.Item1;
            // We have reached the last pic
            if (newKey.Item2)
            {
                pic_next.Visible = false;
            }
            else
            {
                pic_previous.Visible = true;
                pic_next.Visible = true;
            }

            label.Text = Text = Key;
            picture.Load(AtRuntime.Settings.GetFile(Key));
        }
    }
}