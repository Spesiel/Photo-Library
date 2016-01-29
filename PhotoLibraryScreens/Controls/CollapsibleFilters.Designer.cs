namespace PhotoLibrary.Screens
{
    partial class CollapsibleFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapsibleFilters));
            this.label = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            this.label.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            // 
            // table
            // 
            resources.ApplyResources(this.table, "table");
            this.table.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.table.Name = "table";
            // 
            // CollapsibleFilters
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.table);
            this.Controls.Add(this.label);
            this.Name = "CollapsibleFilters";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TableLayoutPanel table;
    }
}
