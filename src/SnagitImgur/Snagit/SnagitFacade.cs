using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SnagitImgur.Services;
using SnagitImgur.Services.Imgur;

namespace SnagitImgur.Snagit
{
    public class SnagitFacade : ISnagitFacade
    {
        private readonly ISnagitHost snagitHost;
        private readonly IImageSharingService service;

        public SnagitFacade(ISnagitHost snagitHost, IImageSharingService service)
        {
            this.snagitHost = snagitHost;
            this.service = service;
        }

        public async Task ShareImage()
        {
            using (ICapturedImage image = snagitHost.GetCapturedImage())
            {
                ImageInfo imageInfo = await service.UploadAsync(image.FileName);

                Process.Start(imageInfo.Link);
            }
        }
    }
}