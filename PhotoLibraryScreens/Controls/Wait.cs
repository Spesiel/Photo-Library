using PhotoLibrary.Reference.Objects;
using System.Windows.Forms;

namespace PhotoLibrary.Screens
{
    public partial class Wait : UserControl
    {
        private delegate void ProgressCallBack(ChangeProgressedEventArgs progress);

        private delegate void CompleteCallBack(ChangeCompletedEventArgs complete);

        public Wait()
        {
            InitializeComponent();
            Change.Progressed += Change_Progressed;
            Change.Completed += Change_Completed;
        }

        private void Change_Progressed(ChangeProgressedEventArgs e)
        {
            if (progress.InvokeRequired)
            {
                Invoke(new ProgressCallBack(Change_Progressed), new object[] { e });
            }
            else
            {
                progress.Value = e.Progress;
            }
        }

        private void Change_Completed(ChangeCompletedEventArgs e)
        {
            if (progress.InvokeRequired)
            {
                Invoke(new CompleteCallBack(Change_Completed), new object[] { e });
            }
            else
            {
                Visible = false;
                Dispose();
            }
        }
    }
}