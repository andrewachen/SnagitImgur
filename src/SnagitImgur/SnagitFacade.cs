using System;
using System.Diagnostics;
using SNAGITLib;

namespace SnagitImgur
{
    public class SnagitFacade : ISnagitFacade
    {
        private readonly ISnagItAsyncOutput asyncOutput;
        //private readonly ITemporaryImageProvider tempImageProvider;
        //private readonly IImageService imageService;

        public SnagitFacade(ISnagIt snagitHost)
        {
            asyncOutput = snagitHost as ISnagItAsyncOutput;
            //this.tempImageProvider = tempImageProvider;
            //this.imageService = imageService;
        }

        public async void SaveImage()
        {
            //using (var tempImage = tempImageProvider.CreateTemporaryImage())
            //{
            //    if (asyncOutput != null)
            //    {
            //        // supported in Snagit v11
            //        asyncOutput.StartAsyncOutput();
            //    }
            //    try
            //    {
            //        string imageUrl = await UploadImageAsync(tempImage);

            //        Process.Start(imageUrl);
            //    }
            //    finally
            //    {
            //        if (asyncOutput != null)
            //        {
            //            // supported in Snagit v11
            //            asyncOutput.FinishAsyncOutput(true);
            //        }
            //    }
            //}
        }
    }
}