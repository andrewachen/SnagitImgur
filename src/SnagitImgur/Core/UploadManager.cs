using System;
using System.ComponentModel;
using System.Diagnostics;
using SNAGITLib;

namespace SnagitImgur.Core
{
    public class UploadManager : IUploadManager
    {
        private readonly ISnagItAsyncOutput snagitAsyncOutput;

        public UploadManager(ISnagItAsyncOutput snagitAsyncOutput)
        {
            this.snagitAsyncOutput = snagitAsyncOutput;
        }

        public event EventHandler UploadCompleted = delegate { };

        public void UploadImageAsync(ITemporaryImage tempImage, IImageSharingService service)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += OnUploadCompleted;
            backgroundWorker.DoWork += (sender, args) =>
            {
                args.Result = service.UploadImage(tempImage.Filename);
            };

            if (snagitAsyncOutput != null)
            {
                // supported in Snagit v11
                snagitAsyncOutput.StartAsyncOutput();
            }

            backgroundWorker.RunWorkerAsync();
        }

        private void OnUploadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (snagitAsyncOutput != null)
            {
                // supported in Snagit v11
                snagitAsyncOutput.FinishAsyncOutput(true);
            }

            var result = e.Result as UploadResult;
            if (result == null)
            {
                throw new InvalidOperationException("Unable to get upload result");
            }

            UploadCompleted(this, EventArgs.Empty);

            Process.Start(result.OriginalImage);
        }
    }
}