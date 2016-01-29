using System;
using System.Globalization;
using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            listStats.Items.Add(NewRow("Number of medias loaded",
                NerdStats.NumberOfMediasLoaded.ToString(CultureInfo.CurrentCulture)));
            listStats.Items.Add(NewRow("Time taken to load everything",
                Math.Round(NerdStats.LoadingTimeInMilliseconds.TotalSeconds
                , 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.CurrentCulture) +
                " s"));
            listStats.Items.Add(NewRow("Time taken to load each item",
                Math.Round((NerdStats.LoadingTimeInMilliseconds.TotalMilliseconds / NerdStats.NumberOfMediasLoaded)
                , 2, MidpointRounding.AwayFromZero) +
                " ms/picture"));
            listStats.Items.Add(NewRow("Items ignored", PhotoWork.Settings.Ignored.Count.ToString(CultureInfo.CurrentCulture)));
        }

        private static ListViewItem NewRow(string col1, string col2)
        {
            ListViewItem row = new ListViewItem(col1);
            row.SubItems.Add(col2);
            return row;
        }
    }
}