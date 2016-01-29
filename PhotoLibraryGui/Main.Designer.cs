namespace PhotoLibrary.Gui
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip_progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip_progressText = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStrip_File = new System.Windows.Forms.ToolStripMenuItem();
            this.openPhotoLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_File_loadDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_About = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_About_stats = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_About_separetor1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip_About_about = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.prime = new PhotoLibrary.Screens.Prime();
            this.toolStrip_news = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_progressBar,
            this.toolStrip_progressText,
            this.toolStrip_news});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStrip_progressBar
            // 
            this.toolStrip_progressBar.Name = "toolStrip_progressBar";
            resources.ApplyResources(this.toolStrip_progressBar, "toolStrip_progressBar");
            // 
            // toolStrip_progressText
            // 
            this.toolStrip_progressText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrip_progressText.Name = "toolStrip_progressText";
            resources.ApplyResources(this.toolStrip_progressText, "toolStrip_progressText");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_File,
            this.menuStrip_About});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // menuStrip_File
            // 
            this.menuStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPhotoLibraryToolStripMenuItem,
            this.menuStrip_File_loadDirectory});
            this.menuStrip_File.Name = "menuStrip_File";
            resources.ApplyResources(this.menuStrip_File, "menuStrip_File");
            // 
            // openPhotoLibraryToolStripMenuItem
            // 
            this.openPhotoLibraryToolStripMenuItem.Name = "openPhotoLibraryToolStripMenuItem";
            resources.ApplyResources(this.openPhotoLibraryToolStripMenuItem, "openPhotoLibraryToolStripMenuItem");
            this.openPhotoLibraryToolStripMenuItem.Click += new System.EventHandler(this.menuStrip_File_openPhotoLibrary_Click);
            // 
            // menuStrip_File_loadDirectory
            // 
            this.menuStrip_File_loadDirectory.Name = "menuStrip_File_loadDirectory";
            resources.ApplyResources(this.menuStrip_File_loadDirectory, "menuStrip_File_loadDirectory");
            this.menuStrip_File_loadDirectory.Click += new System.EventHandler(this.menuStrip_File_loadDirectory_Click);
            // 
            // menuStrip_About
            // 
            this.menuStrip_About.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_About_stats,
            this.menuStrip_About_separetor1,
            this.menuStrip_About_about});
            this.menuStrip_About.Name = "menuStrip_About";
            resources.ApplyResources(this.menuStrip_About, "menuStrip_About");
            // 
            // menuStrip_About_stats
            // 
            this.menuStrip_About_stats.Name = "menuStrip_About_stats";
            resources.ApplyResources(this.menuStrip_About_stats, "menuStrip_About_stats");
            this.menuStrip_About_stats.Click += new System.EventHandler(this.menuStrip_About_stats_Click);
            // 
            // menuStrip_About_separetor1
            // 
            this.menuStrip_About_separetor1.Name = "menuStrip_About_separetor1";
            resources.ApplyResources(this.menuStrip_About_separetor1, "menuStrip_About_separetor1");
            // 
            // menuStrip_About_about
            // 
            this.menuStrip_About_about.Name = "menuStrip_About_about";
            resources.ApplyResources(this.menuStrip_About_about, "menuStrip_About_about");
            this.menuStrip_About_about.Click += new System.EventHandler(this.menuStrip_About_about_Click);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // prime
            // 
            resources.ApplyResources(this.prime, "prime");
            this.prime.Name = "prime";
            // 
            // toolStrip_news
            // 
            this.toolStrip_news.Name = "toolStrip_news";
            resources.ApplyResources(this.toolStrip_news, "toolStrip_news");
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.prime);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStrip_progressBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_File;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_File_loadDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_progressText;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_About;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_About_stats;
        private System.Windows.Forms.ToolStripMenuItem openPhotoLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator menuStrip_About_separetor1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_About_about;
        private Screens.Prime prime;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_news;
    }
}

