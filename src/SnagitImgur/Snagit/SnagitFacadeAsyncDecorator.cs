using System.Threading.Tasks;

namespace SnagitImgur.Snagit
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

        public async Task ShareImage()
        {
            snagitHost.StartAsyncOutput();

            bool isSuccessful = false;
            try
            {
                await snagitFacade.ShareImage();
                isSuccessful = true;
            }
            catch
            {
                isSuccessful = false;
                throw;
            }
            finally
            {
                snagitHost.FinishAsyncOutput(isSuccessful);
            }
        }
    }
}