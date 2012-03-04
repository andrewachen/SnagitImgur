using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

using SnagitImgur.Properties;

namespace SnagitImgur.Core
{
    public class ImgurService : IImageSharingService, IDisposable
    {
        private readonly Uri imgurApiUrl;
        private readonly string anonymousApiKey;
        private readonly WebClient webClient;

        public event EventHandler<UploadEventArgs> UploadCompleted = delegate { };

        public ImgurService()
        {
            imgurApiUrl = new Uri(Settings.Default.ImgurApiUrl);
            anonymousApiKey = Settings.Default.ImgurAnonymousKey;
            webClient = new WebClient();
        }

        public void UploadImageAsync(string fileName)
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
            
            webClient.UploadValuesCompleted += UploadValuesCompleted;
            webClient.UploadValuesAsync(imgurApiUrl, values);
            webClient.UploadValues(imgurApiUrl, values);
        }

        private void UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            using (var xmlTextReader = new XmlTextReader(new MemoryStream(e.Result)))
            {
                XDocument result = XDocument.Load(xmlTextReader);

                Uri imgUrl = ParseResult(result);

                RaiseCompletedEvent(imgUrl);
            }
        }

        private void RaiseCompletedEvent(Uri imgUrl)
        {
            UploadCompleted(this, new UploadEventArgs(imgUrl));
        }

        private Uri ParseResult(XDocument result)
        {
            string imgurUrl = (from node in result.Descendants("original_image")
                               select node.Value).SingleOrDefault();

            if (string.IsNullOrEmpty(imgurUrl))
            {
                throw new InvalidOperationException("There was an error uploading the image to Imgur");
            }

            return new Uri(imgurUrl);
        }

        public void Dispose()
        {
            if (webClient != null)
            {
                webClient.Dispose();
            }
        }
    }
}