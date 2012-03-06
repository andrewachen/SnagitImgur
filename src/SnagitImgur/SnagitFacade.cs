using System;
using System.Diagnostics;
using SNAGITLib;
using SnagitImgur.Core;

namespace SnagitImgur
{
    public class SnagitFacade
    {
        private readonly ISnagItAsyncOutput asyncOutput;
        private readonly ITemporaryImageProvider tempImageProvider;
        private readonly IImageSharingService imageService;

        public SnagitFacade(ISnagIt snagitHost, ITemporaryImageProvider tempImageProvider, IImageSharingService imageService)
        {
            this.asyncOutput = snagitHost as ISnagItAsyncOutput;
            this.tempImageProvider = tempImageProvider;
            this.imageService = imageService;

        }

        public void SaveImage()
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
                    var result = imageService.UploadImage(tempImage.Filename);

                    if (!string.IsNullOrEmpty(result.OriginalImage))
                    {
                        Process.Start(result.OriginalImage);
                    }
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
    }
}