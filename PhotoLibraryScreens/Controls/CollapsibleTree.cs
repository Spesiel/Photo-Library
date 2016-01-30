using PhotoLibrary.Reference;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class CollapsibleTree : UserControl
    {
        public TreeView Tree { get { return tree; } }

        private Size SizeCollapsed { get; set; }
        private Size SizeExpanded { get; set; }

        public CollapsibleTree()
        {
            InitializeComponent();
        }

        public void LoadTree()
        {
            tree.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(AtRuntime.Settings.GetDirectory);
            tree.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));

            tree.ExpandAll();
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            return directoryNode;
        }

        public void SetCollapsingParameters(Size control, bool collapsed)
        {
            Size sizeCollapsed = SizeExpanded = control;
            sizeCollapsed.Height = label.Height;
            SizeCollapsed = sizeCollapsed;

            // Requested collapsed by default
            if (collapsed)
            {
                tree.Visible = true;
                label_DoubleClick(null, null);
            }
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            tree.Visible = !tree.Visible;

            // Depending on visibility, the component is either collapsed or not
            Size = tree.Visible ? SizeExpanded : SizeCollapsed;
        }
    }
}