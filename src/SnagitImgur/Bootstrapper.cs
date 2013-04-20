using SNAGITLib;
using SimpleInjector;
using SimpleInjector.Extensions;
using SnagitImgur.Properties;
using SnagitImgur.Services;
using SnagitImgur.Services.Imgur;
using SnagitImgur.Snagit;

namespace SnagitImgur
{
    internal static class Bootstrapper
    {
        public static ISnagitFacade Bootstrap(ISnagIt snagit)
        {
            var container = new Container();

            container.RegisterSingle<ISnagitHost>(() => new SnagitHost(snagit));
            container.RegisterSingle<IImageSharingService>(() => new ImgurService(Settings.Default.ClientID));
            container.RegisterSingle<ISnagitFacade, SnagitFacade>();
            container.RegisterDecorator(typeof(ISnagitFacade), typeof(SnagitFacadeAsyncDecorator));

            return container.GetInstance<ISnagitFacade>();
        }
    }
}