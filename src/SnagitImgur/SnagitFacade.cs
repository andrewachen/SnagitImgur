using SnagitImgur.Core;

namespace SnagitImgur
{
    public class SnagitFacade
    {
        private readonly IUploadManager uploadManager;
        private readonly ITemporaryImageProvider tempImageProvider;
        private readonly IImageSharingService sharingService;

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
            
            uploadManager.UploadImageAsync(tempImage, sharingService);
        }
    }
}