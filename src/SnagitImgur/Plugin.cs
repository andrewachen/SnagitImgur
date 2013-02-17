using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using SNAGITLib;

using SnagitImgur.Core;

namespace SnagitImgur
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("681D1A5C-A78F-4D27-86A2-A07AAC89B8FE")]
    public class Plugin : MarshalByRefObject, IComponentInitialize, IOutput
    {
        private SnagitFacade snagitFacade;

        public void Output()
        {
            Action saveImageAction = snagitFacade.SaveImage;
            try
            {
                IAsyncResult result = saveImageAction.BeginInvoke(null, null);
                if (result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(30)))
                {
                    saveImageAction.EndInvoke(result);
                }
            }
            catch (Exception e)
            {
                // todo temp code, replace with proper reporting!
                MessageBox.Show("An unhandled exception occured:\n" + e);
            }
        }

        public void InitializeComponent(object pExtensionHost, IComponent pComponent, componentInitializeType initType)
        {
            try
            {
                var snagitHost = pExtensionHost as ISnagIt;
                if (snagitHost == null)
                {
                    throw new InvalidOperationException("Unable to communicate with Snagit");
                }

                var imgurService = new ImgurService();
                var temporaryImageProvider = new TemporaryImageProvider(snagitHost);
                snagitFacade = new SnagitFacade(snagitHost, temporaryImageProvider, imgurService);
            }
            catch (Exception e)
            {
                // todo temp code, replace with proper reporting!
                MessageBox.Show("An unhandled exception occured:\n" + e);
            }
        }
    }
}