using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SnagitImgur
{
    public class Imgur : ImageSharingServiceBase
    {
        private const string ImgurApiUrl = "http://api.imgur.com/2/upload.json";
        private const string AnonymousImgurKey = "21b7aa9b01f8462d69d716853bb532d0";

        private readonly Uri address;

        public Imgur(HttpClient httpClient)
            : base(httpClient)
        {
            address = new Uri(ImgurApiUrl);
        }

        public override async Task<dynamic> UploadImageAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var values = new NameValueCollection
            {
                {"key", AnonymousImgurKey},
                {"image", Convert.ToBase64String(File.ReadAllBytes(fileName))}
            };


            var response = await httpClient.PostAsync(address, new ByteArrayContent(File.ReadAllBytes(fileName)));
            
            using (var streamReader = new StreamReader(new MemoryStream(response.Content.ReadAsByteArrayAsync().Result)))
            {
                return new JsonFx.Json.JsonReader().Read(streamReader);
            }
        }
    }
}