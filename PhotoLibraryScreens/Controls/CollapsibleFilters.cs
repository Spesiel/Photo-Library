using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class CollapsibleFilters : UserControl
    {
        private Size SizeCollapsed { get; set; }
        private Size SizeExpanded { get; set; }

        public CollapsibleFilters()
        {
            InitializeComponent();
        }

        public void SetCollapsingParameters(Size control, bool collapsed)
        {
            Size sizeCollapsed = SizeExpanded = control;
            sizeCollapsed.Height = label.Height;
            SizeCollapsed = sizeCollapsed;

            // Requested collapsed by default
            if (collapsed)
            {
                table.Visible = true;
                label_DoubleClick(null, null);
            }
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            table.Visible = !table.Visible;

            // Depending on visibility, the component is either collapsed or not
            Size = table.Visible ? SizeExpanded : SizeCollapsed;
        }
    }
}