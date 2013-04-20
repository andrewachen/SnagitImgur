using System.Threading.Tasks;

namespace SnagitImgur
{
    public interface IImageSharingService
    {
        Task<ImageInfo> UploadAsync(string imagePath);
    }
}