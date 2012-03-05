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
            backgroundWorker.RunWorkerCompleted += OnUploadCompleted;
            backgroundWorker.DoWork += (sender, args) =>
            {
                args.Result = service.UploadImage(tempImage.Filename);
            };

            snagitAsyncOutput.StartAsyncOutput();
            backgroundWorker.RunWorkerAsync();
        }

        private void OnUploadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            snagitAsyncOutput.FinishAsyncOutput(true);

            var result = e.Result as UploadResult;
            if (result == null)
            {
                throw new InvalidOperationException("Unable to get upload result");
            }

            Process.Start(result.OriginalImage);
        }
    }
}