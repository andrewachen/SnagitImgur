using System;

namespace SnagitImgur.Core
{
    public interface IImageSharingService
    {
        UploadResult UploadImage(string fileName);
    }
}