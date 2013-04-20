using SNAGITLib;

namespace SnagitImgur
{
    public class SnagitFacadeAsyncDecorator : ISnagitFacade
    {
        private readonly ISnagitFacade snagitFacade;
        private readonly ISnagitHost snagitHost;

        public SnagitFacadeAsyncDecorator(ISnagitFacade snagitFacade, ISnagitHost snagitHost)
        {
            this.snagitFacade = snagitFacade;
            this.snagitHost = snagitHost;
        }

        public void ShareImage()
        {
            snagitHost.StartAsyncOutput();

            bool isSuccessful = false;
            try
            {
                snagitFacade.ShareImage();
                isSuccessful = true;
            }
            catch
            {
                isSuccessful = false;
            }
            finally
            {
                snagitHost.FinishAsyncOutput(isSuccessful);
            }
        }
    }
}