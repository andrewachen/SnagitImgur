using SNAGITLib;
using SimpleInjector;
using SimpleInjector.Extensions;
using SnagitImgur.Properties;

namespace SnagitImgur
{
    internal static class Bootstrapper
    {
        public static ISnagitFacade Bootstrap(ISnagIt snagit)
        {
            var container = new Container();

            container.RegisterSingle<ISnagitHost>(() => new SnagitHost(snagit));
            container.RegisterSingle<IImageSharingService>(() => new Imgur(Settings.Default.ClientID));
            container.RegisterSingle<ISnagitFacade, SnagitFacade>();
            container.RegisterDecorator(typeof(ISnagitFacade), typeof(SnagitFacadeAsyncDecorator));

            return container.GetInstance<ISnagitFacade>();
        }
    }
}