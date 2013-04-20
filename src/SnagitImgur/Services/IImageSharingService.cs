using System.Threading.Tasks;
using SnagitImgur.Services.Imgur;

namespace SnagitImgur.Services
{
    public interface IImageSharingService
    {
        Task<ImageInfo> UploadAsync(string imagePath);
    }
}