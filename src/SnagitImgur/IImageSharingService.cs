using System;
using System.Threading.Tasks;

namespace SnagitImgur
{
    public interface IImageSharingService
    {
        Task<dynamic> UploadImageAsync(string fileName);
    }
}