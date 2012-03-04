using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

using SNAGITLib;

namespace SnagitImgur.Core
{
    public class UploadManager : IUploadManager
    {
        private readonly ISnagItAsyncOutput snagitAsyncOutput;

        public UploadManager(ISnagItAsyncOutput snagitAsyncOutput)
        {
            this.snagitAsyncOutput = snagitAsyncOutput;
            if (snagitAsyncOutput == null)
            {
                throw new InvalidOperationException("Unable to get Snagit's asynchronous operation handler");
            }
        }

        public void UploadImageAsync(ITemporaryImage tempImage, IImageSharingService service)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (sender, args) =>
            {
                service.UploadCompleted += OnUploadCompleted;
                service.UploadImageAsync(tempImage.Filename);
            };

            snagitAsyncOutput.StartAsyncOutput();
            backgroundWorker.RunWorkerAsync();
        }

        private void OnUploadCompleted(object sender, UploadEventArgs e)
        {
            snagitAsyncOutput.FinishAsyncOutput(true);

            Process.Start(e.Uri.AbsoluteUri);
        }
    }
}