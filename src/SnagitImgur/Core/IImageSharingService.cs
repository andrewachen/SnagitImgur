using System;

namespace SnagitImgur.Core
{
    public interface IImageSharingService
    {
        event EventHandler<UploadEventArgs> UploadCompleted;

        void UploadImageAsync(string fileName);
    }
}