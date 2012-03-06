using System;

namespace SnagitImgur.Core
{
    public interface IUploadManager
    {
        event EventHandler UploadCompleted;

        void UploadImageAsync(ITemporaryImage tempImage, IImageSharingService service);
    }
}