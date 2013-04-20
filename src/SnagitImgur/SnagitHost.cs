using System;
using System.IO;
using SNAGITLib;

namespace SnagitImgur
{
    public class SnagitHost : ISnagitHost
    {
        private readonly ISnagIt snagit;
        private readonly ISnagItAsyncOutput asyncOutput;

        public SnagitHost(ISnagIt snagit)
        {
            this.snagit = snagit;
            asyncOutput = snagit as ISnagItAsyncOutput;
        }

        public ICapturedImage GetCapturedImage()
        {
            ISnagItDocument snagItDocument = snagit.SelectedDocument;
            var imageDocumentSave = snagItDocument as ISnagItImageDocumentSave;
            if (imageDocumentSave == null)
            {
                throw new InvalidCastException("Unable to get image saving facility of Snagit");
            }

            string tempFileName = Path.GetTempFileName() + ".png";
            imageDocumentSave.SaveToFile(ref tempFileName, snagImageFileType.siftPNG, null);

            return new TemporaryImage(tempFileName);
        }

        public void StartAsyncOutput()
        {
            if (asyncOutput != null)
            {
                asyncOutput.StartAsyncOutput();
            }
        }

        public void FinishAsyncOutput(bool isSuccessful)
        {
            if (asyncOutput != null)
            {
                asyncOutput.FinishAsyncOutput(isSuccessful);
            }
        }

        private class TemporaryImage : ICapturedImage
        {
            private readonly string fileName;

            public string FileName 
            {
                get { return fileName; }
            }

            public TemporaryImage(string fileName)
            {
                this.fileName = fileName;
            }

            public void Dispose()
            {
                File.Delete(fileName);
            }
        }
    }
}