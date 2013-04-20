using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SNAGITLib;
using SnagitImgur.Services;
using SnagitImgur.Snagit;

namespace SnagitImgur
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("681D1A5C-A78F-4D27-86A2-A07AAC89B8FE")]
    public class Plugin : MarshalByRefObject, IComponentInitialize, IOutput
    {
        private ISnagitFacade snagitFacade;

        public void InitializeComponent(object pExtensionHost, IComponent pComponent, componentInitializeType initType)
        {
            var snagitHost = pExtensionHost as ISnagIt;
            if (snagitHost == null)
            {
                throw new InvalidOperationException("Unable to communicate with Snagit");
            }
            
            snagitFacade = Bootstrapper.Bootstrap(snagitHost);
        }

        public async void Output()
        {
            try
            {
                await snagitFacade.ShareImage();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
    }
}