using System;
using System.Runtime.InteropServices;
using SNAGITLib;

namespace SnagitImgur
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("681D1A5C-A78F-4D27-86A2-A07AAC89B8FE")]
    public class Plugin : MarshalByRefObject, IComponentInitialize, IOutput, IComponentTerminate
    {
        private ISnagitFacade snagitFacade;

        public void InitializeComponent(object pExtensionHost, IComponent pComponent, componentInitializeType initType)
        {
            var snagitHost = pExtensionHost as ISnagIt;
            if (snagitHost == null)
            {
                throw new InvalidOperationException("Unable to communicate with Snagit");
            }

            var imgurService = new Imgur();
            var temporaryImageProvider = new TemporaryImageProvider(snagitHost);
            snagitFacade = new SnagitFacade(snagitHost, temporaryImageProvider, imgurService);
        }

        public void Output()
        {
            // TODO
            //var viewModel = new UploadViewModel(snagitFacade);
            //var view = new UploadView
            //{
            //    DataContext = viewModel
            //};

            //view.ShowDialog();

            snagitFacade.SaveImage();
        }

        public void TerminateComponent(componentTerminateType termType)
        {
            
        }
    }
}