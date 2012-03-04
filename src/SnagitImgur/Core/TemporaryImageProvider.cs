using System;
using System.IO;

using SNAGITLib;

namespace SnagitImgur.Core
{
    public class TemporaryImageProvider : ITemporaryImageProvider
    {
        private readonly ISnagIt snagitHost;
        private string tempFileName;

        public TemporaryImageProvider(ISnagIt snagitHost)
        {
            this.snagitHost = snagitHost;
            tempFileName = string.Empty;
        }

        public ITemporaryImage CreateTemporaryImage()
        {
            ISnagItDocument snagItDocument = snagitHost.SelectedDocument;
            ISnagItImageDocumentSave imageDocumentSave = snagItDocument as ISnagItImageDocumentSave;
            if (imageDocumentSave == null)
            {
                throw new InvalidCastException("Unable to get image saving facility of Snagit");
            }

            tempFileName = Path.GetTempFileName() + ".png";
            imageDocumentSave.SaveToFile(ref tempFileName, snagImageFileType.siftPNG, null);

            return new TemporaryImage(tempFileName);
        }
    }
}