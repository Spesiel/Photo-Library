using System.IO;
using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class Prime : UserControl
    {
        public Sidebar Sidebar { get { return sidebar; } }
        public ListView ListView { get { return listView; } }

        private string ListViewFilter { get; set; }

        public Prime()
        {
            InitializeComponent();

            // A node from the tree has been clicked
            Sidebar.Tree.Tree.NodeMouseClick += (s, args) =>
            {
                int index = args.Node.FullPath.IndexOf(Path.DirectorySeparatorChar);
                // Get the path we want
                if (index >= 0)
                {
                    ListViewFilter = args.Node.FullPath.Substring(index + 1);
                }
                else
                {
                    ListViewFilter = null;
                }
                ListView.Clear();
                ListView.VirtualListSize = Navigation.CountValues(ListViewFilter);
            };
        }

        #region listview

        private void listview_onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = listView.HitTest(e.Location);

            // No hit
            if (hit.Item.Equals(null))
            {
                return;
            }
            else
            {
                using (Preview preview = new Preview(ListViewFilter, hit.Item.Text))
                {
                    preview.ShowDialog();
                }
            }
        }

        private void listview_onRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //A cache hit, so get the ListViewItem from the cache instead of making a new one.
            e.Item = new ListViewItem(Navigation.GetKey(ListViewFilter, e.ItemIndex));
        }

        private void listview_onDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Actions.GenerateThumbnail(listView.BackColor, e.Item.Text);
            e.Graphics.DrawImage(Navigation.GetThumbnail(e.Item.Text), e.Bounds);
        }

        private void listview_onSearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            //TODO We have a search request.
        }

        #endregion listview
    }
}