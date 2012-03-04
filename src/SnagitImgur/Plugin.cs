using System;
using System.Diagnostics;
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
            try
            {
                snagitFacade.SaveImage();
            }
            catch (Exception e)
            {
                // todo temp code, replace with proper reporting!
                MessageBox.Show("An unandled exception occured:\n" + e);
            }
        }

        public void InitializeComponent(object pExtensionHost, IComponent pComponent, componentInitializeType initType)
        {
            var snagitHost = pExtensionHost as ISnagIt;
            if (snagitHost == null)
            {
                throw new InvalidOperationException("Unable to communicate with Snagit");
            }

            var imgurService = new ImgurService();
            var uploadManager = new UploadManager(snagitHost as ISnagItAsyncOutput);
            var temporaryImageProvider = new TemporaryImageProvider(snagitHost);
            snagitFacade = new SnagitFacade(uploadManager, temporaryImageProvider, imgurService);
        }
    }
}