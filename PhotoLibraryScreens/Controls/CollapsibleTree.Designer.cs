namespace PhotoLibrary.Screens
{
    partial class CollapsibleTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapsibleTree));
            this.label = new System.Windows.Forms.Label();
            this.tree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            this.label.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            // 
            // tree
            // 
            resources.ApplyResources(this.tree, "tree");
            this.tree.Name = "tree";
            // 
            // CollapsibleTree
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.label);
            this.Name = "CollapsibleTree";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TreeView tree;
    }
}
