using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class Sidebar : UserControl
    {
        public CollapsibleTree Tree { get { return collapsibleTree; } }

        public Sidebar()
        {
            InitializeComponent();

            collapsibleTree.SetCollapsingParameters(collapsibleTree.Size, false);
            collapsibleFilters.SetCollapsingParameters(collapsibleFilters.Size, true);
        }
    }
}