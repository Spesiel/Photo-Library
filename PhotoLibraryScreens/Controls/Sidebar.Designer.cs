namespace PhotoLibrary.Screens
{
    partial class Sidebar
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
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.collapsibleFilters = new PhotoLibrary.Screens.CollapsibleFilters();
            this.collapsibleTree = new PhotoLibrary.Screens.CollapsibleTree();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.collapsibleFilters, 0, 1);
            this.table.Controls.Add(this.collapsibleTree, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Size = new System.Drawing.Size(168, 440);
            this.table.TabIndex = 2;
            // 
            // collapsibleFilters
            // 
            this.collapsibleFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.collapsibleFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsibleFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleFilters.Location = new System.Drawing.Point(3, 245);
            this.collapsibleFilters.Name = "collapsibleFilters";
            this.collapsibleFilters.Size = new System.Drawing.Size(162, 192);
            this.collapsibleFilters.TabIndex = 0;
            // 
            // collapsibleTree
            // 
            this.collapsibleTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsibleTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleTree.Location = new System.Drawing.Point(3, 3);
            this.collapsibleTree.Name = "collapsibleTree";
            this.collapsibleTree.Size = new System.Drawing.Size(162, 236);
            this.collapsibleTree.TabIndex = 1;
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.table);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(168, 440);
            this.table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CollapsibleFilters collapsibleFilters;
        private CollapsibleTree collapsibleTree;
        private System.Windows.Forms.TableLayoutPanel table;
    }
}
