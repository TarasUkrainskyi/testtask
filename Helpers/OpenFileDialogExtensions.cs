using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TestTask.Helpers
{
    public static class OpenFileDialogExtensions
    {
        public static void SetValidateSettings(this OpenFileDialog ofd, string filter, int maxSize)
        {
            ofd.Filter = filter;
            ValidateSizeFile(ofd, maxSize);
        }

        static void ValidateSizeFile(OpenFileDialog ofd, int maxSize)
        {
            ofd.FileOk += delegate (object s, CancelEventArgs ev)
            {
                var size = new FileInfo(ofd.FileName).Length;

                if (ev.Cancel != true && size > maxSize)
                {
                    MessageBox.Show("Sorry, file is too large", "Error");
                    ev.Cancel = true;
                }
            };
        }
    }
}
