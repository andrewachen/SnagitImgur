using System;
using System.IO;

namespace SnagitImgur.Core
{
    internal class TemporaryImage : ITemporaryImage
    {
        public string Filename { get; private set; }

        public TemporaryImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            Filename = fileName;
        }

        public void Delete()
        {
            File.Delete(Filename);
        }

        public void Dispose()
        {
            Delete();
        }
    }
}