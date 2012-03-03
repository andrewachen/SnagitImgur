namespace SnagitImgur
{
    public class SnagitFacade
    {
        private readonly ITemporaryImageProvider imageProvider;
        private readonly IImageSharingService sharingService;

        public SnagitFacade(ITemporaryImageProvider imageProvider, IImageSharingService sharingService)
        {
            this.imageProvider = imageProvider;
            this.sharingService = sharingService;
        }

        public void SaveImage()
        {

        }
    }

    public interface ITemporaryImageProvider
    {
    }

    public interface IImageSharingService
    {
    }

    public interface ITemporaryImage
    {

    }
}