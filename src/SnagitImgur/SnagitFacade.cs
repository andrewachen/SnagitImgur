using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SNAGITLib;

namespace SnagitImgur
{
    public class SnagitFacade : ISnagitFacade
    {
        private readonly ISnagItAsyncOutput asyncOutput;
        private readonly ITemporaryImageProvider tempImageProvider;
        private readonly IImageSharingService imageSharingService;

        public SnagitFacade(ISnagIt snagitHost, ITemporaryImageProvider tempImageProvider, IImageSharingService imageSharingService)
        {
            asyncOutput = snagitHost as ISnagItAsyncOutput;
            this.tempImageProvider = tempImageProvider;
            this.imageSharingService = imageSharingService;
        }

        public async void SaveImage()
        {
            using (var tempImage = tempImageProvider.CreateTemporaryImage())
            {
                if (asyncOutput != null)
                {
                    // supported in Snagit v11
                    asyncOutput.StartAsyncOutput();
                }
                try
                {
                    string imageUrl = await UploadImageAsync(tempImage);

                    Process.Start(imageUrl);
                }
                finally
                {
                    if (asyncOutput != null)
                    {
                        // supported in Snagit v11
                        asyncOutput.FinishAsyncOutput(true);
                    }
                }
            }
        }

        private async Task<string> UploadImageAsync(ITemporaryImage tempImage)
        {
            var result = await imageSharingService.UploadImageAsync(tempImage.Filename);

            return result.upload.links.original;
        }
    }
}