using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using SnagitImgur.Properties;

namespace SnagitImgur.Core
{
    public class ImgurService : IImageSharingService
    {
        private readonly Uri imgurApiUrl;
        private readonly string anonymousApiKey;

        public ImgurService()
        {
            imgurApiUrl = new Uri(Settings.Default.ImgurApiUrl);
            anonymousApiKey = Settings.Default.ImgurAnonymousKey;
        }

        public UploadResult UploadImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var values = new NameValueCollection
            {
                { "key", anonymousApiKey }, 
                { "image", Convert.ToBase64String(File.ReadAllBytes(fileName)) } 
            };

            using (var w = new WebClient())
            {
                byte[] response = w.UploadValues(imgurApiUrl, values);

                using (var xmlTextReader = new XmlTextReader(new MemoryStream(response)))
                {
                    var serializer = new XmlSerializer(typeof(UploadResult));
                    return (UploadResult)serializer.Deserialize(xmlTextReader);
                };
            }
        }
    }
}