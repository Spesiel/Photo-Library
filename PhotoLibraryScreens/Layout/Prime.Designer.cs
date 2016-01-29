namespace PhotoLibrary.Screens
{
    partial class Prime
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.split = new System.Windows.Forms.SplitContainer();
            this.sidebar = new PhotoLibrary.Screens.Sidebar();
            this.listView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.sidebar);
            this.split.Panel1MinSize = 160;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.listView);
            this.split.Size = new System.Drawing.Size(800, 600);
            this.split.SplitterDistance = 163;
            this.split.TabIndex = 0;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(163, 600);
            this.sidebar.TabIndex = 0;
            // 
            // listview
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listview";
            this.listView.OwnerDraw = true;
            this.listView.Size = new System.Drawing.Size(633, 600);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.VirtualMode = true;
            this.listView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listview_onDrawItem);
            this.listView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listview_onRetrieveVirtualItem);
            this.listView.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.listview_onSearchForVirtualItem);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listview_onMouseDoubleClick);
            // 
            // Prime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split);
            this.Name = "Prime";
            this.Size = new System.Drawing.Size(800, 600);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private Sidebar sidebar;
        private System.Windows.Forms.ListView listView;
    }
}
