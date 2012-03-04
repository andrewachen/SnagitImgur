using System;

namespace SnagitImgur.Core
{
    public interface IUploadManager
    {
        void UploadImageAsync(ITemporaryImage tempImage, IImageSharingService service);
    }
}