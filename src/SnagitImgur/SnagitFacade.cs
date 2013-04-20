using System;
using System.Diagnostics;

namespace SnagitImgur
{
    public class SnagitFacade : ISnagitFacade
    {
        private readonly ISnagitHost snagitHost;
        private readonly Imgur imgur;

        public SnagitFacade(ISnagitHost snagitHost, Imgur imgur)
        {
            this.snagitHost = snagitHost;
            this.imgur = imgur;
        }

        public async void ShareImage()
        {
            using (ICapturedImage image = snagitHost.GetCapturedImage())
            {
                ImageInfo imageInfo = await imgur.UploadAsync(image.FileName);

                Process.Start(imageInfo.Link);
            }
        }
    }
}