﻿using System;
using System.Diagnostics;

namespace SnagitImgur
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

        public async void ShareImage()
        {
            using (ICapturedImage image = snagitHost.GetCapturedImage())
            {
                ImageInfo imageInfo = await service.UploadAsync(image.FileName);

                Process.Start(imageInfo.Link);
            }
        }
    }
}