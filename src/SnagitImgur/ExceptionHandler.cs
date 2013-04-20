using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SnagitImgur
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            // todo replace this with a proper dialog

            if (MessageBox.Show(
                "Well, this is embarrassing... Something went wrong while uploading the image." + Environment.NewLine +
                "Here is what happened:" + Environment.NewLine +
                "----------------------------------------------------------------------------" + Environment.NewLine +
                ex + Environment.NewLine +
                "----------------------------------------------------------------------------" + Environment.NewLine +
                "I'd appreciate if you could paste the details above on github. Press Ctrl+C " +
                "to copy all this text to clipboard, then press OK to open the 'Issues' page.",
                "Ooops...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Process.Start("https://github.com/hmemcpy/SnagitImgur/issues");
            }
        }
    }
}