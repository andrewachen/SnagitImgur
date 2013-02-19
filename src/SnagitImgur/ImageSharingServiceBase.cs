using System.Net.Http;
using System.Threading.Tasks;

namespace SnagitImgur
{
    public abstract class ImageSharingServiceBase : IImageSharingService
    {
        protected readonly HttpClient httpClient;

        protected ImageSharingServiceBase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public abstract Task<dynamic> UploadImageAsync(string fileName);
    }
}