using System;
using System.Collections.Generic;
using SnagitImgur.Core;

namespace SnagitImgur
{
    public class SnagitFacade : IDisposable
    {
        private bool disposed;
        private readonly IUploadManager uploadManager;
        private readonly ITemporaryImageProvider tempImageProvider;
        private readonly IImageSharingService sharingService;

        private readonly List<ITemporaryImage> temporaryImages = new List<ITemporaryImage>();

        public SnagitFacade(IUploadManager uploadManager,
                            ITemporaryImageProvider tempImageProvider, 
                            IImageSharingService sharingService)
        {
            this.uploadManager = uploadManager;
            this.tempImageProvider = tempImageProvider;
            this.sharingService = sharingService;

        }

        public void SaveImage()
        {
            ITemporaryImage tempImage = tempImageProvider.CreateTemporaryImage();
            temporaryImages.Add(tempImage);
            
            uploadManager.UploadImageAsync(tempImage, sharingService);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    temporaryImages.ForEach(image => image.Dispose());
                }

                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}