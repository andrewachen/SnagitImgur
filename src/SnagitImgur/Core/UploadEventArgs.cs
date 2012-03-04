using System;

namespace SnagitImgur.Core
{
    public class UploadEventArgs : EventArgs
    {
        public Uri Uri { get; set; }

        public UploadEventArgs(Uri uri)
        {
            Uri = uri;
        }
    }
}