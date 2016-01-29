using PhotoLibrary.Globalization;
using PhotoLibrary.Screens;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PhotoLibrary.Gui
{
    public partial class Main : Form
    {
        private static bool LoadingOccured { get; set; }

        public Main()
        {
            LoadingOccured = false;

            InitializeComponent();

            // When there's a request for the form to close, save everything
            this.FormClosing += (s, args) =>
            {
                if (LoadingOccured) PhotoWork.SaveLibrary();
            };
        }

        #region menuStrip_File

        /// <summary>
        /// Loads the existing library
        /// </summary>
        private void menuStrip_File_openPhotoLibrary_Click(object sender, EventArgs e)
        {
            if (File.Exists(Constants.BaseFullPath))
            {
                PhotoWork.LoadLibrary();
                int[] checkUpdate = PhotoWork.CheckForUpdatesOnLibrary();
                SetupForDisplay();

                // We know the checkUpdate is an array of 2 strings
                toolStrip_news.Text = String.Format(CultureInfo.InvariantCulture,
                    Literals.MediasUpdate, checkUpdate[0], checkUpdate[1]);
                toolStrip_news.Visible = true;
                using (BackgroundWorker bw = new BackgroundWorker())
                {
                    bw.DoWork += (s, args) =>
                    {
                        // Sleep for a minute
                        System.Threading.Thread.Sleep(60000);
                        toolStrip_news.Visible = false;
                        toolStrip_news.Text = string.Empty;
                    };
                    bw.RunWorkerAsync();
                };
            }
            else
            {
                // No library exists. Creating one.
                menuStrip_File_loadDirectory_Click(null, null);
            }

            LoadingOccured = true;
        }

        /// <summary>
        /// Open a dialog to select a starting folder.
        /// </summary>
        private void menuStrip_File_loadDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // For the stats
                DateTime start;

                // Create a background worker to show progress
                using (BackgroundWorker bw = new BackgroundWorker())
                {
                    bw.WorkerReportsProgress = true;

                    // Progress bar
                    toolStrip_progressBar.Visible = true;
                    toolStrip_progressBar.Value = 0;

                    // Events for the background worker
                    bw.DoWork += (s, args) =>
                    {
                        PhotoWork.LoadDirectory(s as BackgroundWorker, folderBrowserDialog.SelectedPath);
                    };

                    // Changes to the status bar as it progresses
                    bw.ProgressChanged += (s, args) =>
                    {
                        toolStrip_progressBar.Value = args.ProgressPercentage;
                        toolStrip_progressText.Text = 100 * LibraryCache.CountValues(null) / NerdStats.NumberOfMediasLoaded + Literals.PercentSign;
                    };

                    // Runs the worker
                    bw.RunWorkerAsync();
                    start = DateTime.Now;

                    // Changes to the status bar when it's done
                    bw.RunWorkerCompleted += (s, args) =>
                    {
                        NerdStats.LoadingTimeInMilliseconds = DateTime.Now - start;
                        toolStrip_progressText.Text = Literals.LoadingDone;
                        toolStrip_progressBar.Value = 0;
                        toolStrip_progressBar.Visible = false;

                        // Save the newly loaded PhotoLibrary
                        PhotoWork.SaveLibrary();

                        // Load the view
                        SetupForDisplay();
                    };
                }

                LoadingOccured = true;
            }
        }

        #endregion menuStrip_File

        #region menuStrip_About

        private void menuStrip_About_stats_Click(object sender, EventArgs e)
        {
            using (Statistics stats = new Statistics())
            {
                stats.ShowDialog();
            }
        }

        private void menuStrip_About_about_Click(object sender, EventArgs e)
        {
            using (About about = new About())
            {
                about.ShowDialog();
            }
        }

        #endregion menuStrip_About

        private void SetupForDisplay()
        {
            // Concerning the Tree
            prime.Sidebar.Tree.LoadTree();

            // Concerning the ListView
            {
                prime.ListView.VirtualListSize = LibraryCache.CountValues(null);

                // Sets the control
                prime.ListView.LargeImageList = new ImageList();
                // Thumbnail size
                prime.ListView.LargeImageList.ImageSize = new Size(128, 128);

                // Create a background worker to show progress
                FetchForThumbnailsAsync();
            }
        }

        private void FetchForThumbnailsAsync()
        {
            toolStrip_progressText.Text = Literals.ThumbnailsLoading;
            toolStrip_progressText.Visible = true;

            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.WorkerReportsProgress = true;

                // Progress bar
                toolStrip_progressBar.Visible = true;
                toolStrip_progressBar.Value = 0;

                // Events for the background worker
                bw.DoWork += (s, args) =>
                {
                    LibraryCache.BackgroundFetchForThumbnails(bw, prime.ListView.BackColor);
                };

                // Changes to the status bar as it progresses
                bw.ProgressChanged += (s, args) =>
                {
                    int percentage = 100 * (LibraryCache.CountValuesWhere(v => v.Thumbnail != null)) /
                        LibraryCache.CountValues(null);
                    if (toolStrip_progressBar != null)
                    {
                        toolStrip_progressBar.Value = percentage;
                        toolStrip_progressText.Text = percentage + Literals.PercentSign + Literals.ThumbnailsLoading;
                    }
                };

                // Changes to the status bar when it's done
                bw.RunWorkerCompleted += (s, args) =>
                {
                    toolStrip_progressBar.Value = 0;
                    toolStrip_progressBar.Visible = false;

                    toolStrip_news.Text = Literals.ThumbnailsCreated;

                    using (BackgroundWorker bw2 = new BackgroundWorker())
                    {
                        bw2.DoWork += (s2, args2) =>
                        {
                            // Sleep for a minute
                            System.Threading.Thread.Sleep(60000);
                            toolStrip_news.Visible = false;
                            toolStrip_news.Text = string.Empty;
                        };
                        bw2.RunWorkerAsync();
                    };

                    FetchForExifAsync();
                };

                // Runs the worker
                bw.RunWorkerAsync();
            }
        }

        private void FetchForExifAsync()
        {
            toolStrip_progressText.Text = Literals.ExifLoading;
            toolStrip_progressText.Visible = true;

            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.WorkerReportsProgress = true;

                // Progress bar
                toolStrip_progressBar.Visible = true;
                toolStrip_progressBar.Value = 0;

                // Events for the background worker
                bw.DoWork += (s, args) =>
                {
                    LibraryCache.BackgroundFetchForExif(bw);
                };

                // Changes to the status bar as it progresses
                bw.ProgressChanged += (s, args) =>
                {
                    int percentage = 100 * (LibraryCache.CountValuesWhere(v => v.Thumbnail != null)) /
                        LibraryCache.CountValues(null);
                    if (toolStrip_progressBar != null)
                    {
                        toolStrip_progressBar.Value = percentage;
                        toolStrip_news.Text = percentage + Literals.PercentSign + Literals.ExifLoading;
                    }
                };

                // Changes to the status bar when it's done
                bw.RunWorkerCompleted += (s, args) =>
                {
                    toolStrip_progressBar.Value = 0;
                    toolStrip_progressBar.Visible = false;

                    toolStrip_news.Text = Literals.ExifAdded;

                    using (BackgroundWorker bw2 = new BackgroundWorker())
                    {
                        bw2.DoWork += (s2, args2) =>
                        {
                            // Sleep for a minute
                            System.Threading.Thread.Sleep(60000);

                            toolStrip_news.Visible = false;
                            toolStrip_news.Text = string.Empty;
                        };
                        bw2.RunWorkerAsync();
                    };
                };

                // Runs the worker
                bw.RunWorkerAsync();
            }
        }
    }
}