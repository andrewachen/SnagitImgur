using System;
using System.IO;
using NUnit.Framework;
using SnagitImgur.Core;

namespace SnagitImgur.Tests
{
    [TestFixture]
    public class ImageUploadTest
    {
        [Test]
        public void UploadTest()
        {
            string imageFileName = Path.GetFullPath("snagitimgur.png");
            
            var service = new ImgurService();
            UploadResult uploadResult = service.UploadImage(imageFileName);

            Assert.IsNotNull(uploadResult);
        }
    }
}