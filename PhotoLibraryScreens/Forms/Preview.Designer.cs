namespace PhotoLibrary.Screens
{
    partial class Preview
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.pic_previous = new System.Windows.Forms.PictureBox();
            this.pic_next = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_next)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            resources.ApplyResources(this.table, "table");
            this.table.Controls.Add(this.picture, 0, 0);
            this.table.Controls.Add(this.pic_previous, 1, 2);
            this.table.Controls.Add(this.pic_next, 4, 2);
            this.table.Controls.Add(this.label, 0, 1);
            this.table.Name = "table";
            // 
            // picture
            // 
            this.table.SetColumnSpan(this.picture, 6);
            resources.ApplyResources(this.picture, "picture");
            this.picture.Name = "picture";
            this.picture.TabStop = false;
            // 
            // pic_previous
            // 
            resources.ApplyResources(this.pic_previous, "pic_previous");
            this.pic_previous.Image = global::PhotoLibrary.Screens.Properties.Resources.Previous;
            this.pic_previous.Name = "pic_previous";
            this.pic_previous.TabStop = false;
            this.pic_previous.Click += new System.EventHandler(this.pic_previous_Click);
            // 
            // pic_next
            // 
            this.pic_next.Image = global::PhotoLibrary.Screens.Properties.Resources.Next;
            resources.ApplyResources(this.pic_next, "pic_next");
            this.pic_next.Name = "pic_next";
            this.pic_next.TabStop = false;
            this.pic_next.Click += new System.EventHandler(this.pic_next_Click);
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.table.SetColumnSpan(this.label, 6);
            this.label.Name = "label";
            // 
            // Preview
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "Preview";
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_next)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.PictureBox pic_previous;
        private System.Windows.Forms.PictureBox pic_next;
        private System.Windows.Forms.Label label;
    }
}