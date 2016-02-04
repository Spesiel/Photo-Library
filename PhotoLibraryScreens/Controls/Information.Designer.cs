namespace PhotoLibrary.Screens.Controls
{
    partial class Information
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.tabInfos = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInfos);
            this.tabControl.Controls.Add(this.tabTags);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.MinimumSize = new System.Drawing.Size(500, 64);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(500, 64);
            this.tabControl.TabIndex = 0;
            // 
            // tabTags
            // 
            this.tabTags.Location = new System.Drawing.Point(4, 22);
            this.tabTags.Margin = new System.Windows.Forms.Padding(0);
            this.tabTags.Name = "tabTags";
            this.tabTags.Size = new System.Drawing.Size(492, 38);
            this.tabTags.TabIndex = 0;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // tabInfos
            // 
            this.tabInfos.Location = new System.Drawing.Point(4, 22);
            this.tabInfos.Margin = new System.Windows.Forms.Padding(0);
            this.tabInfos.Name = "tabInfos";
            this.tabInfos.Size = new System.Drawing.Size(492, 38);
            this.tabInfos.TabIndex = 1;
            this.tabInfos.Text = "Informations";
            this.tabInfos.UseVisualStyleBackColor = true;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(500, 64);
            this.Name = "Information";
            this.Size = new System.Drawing.Size(500, 64);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.TabPage tabInfos;
    }
}
