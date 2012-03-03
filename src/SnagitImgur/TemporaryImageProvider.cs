using System;

namespace SnagitImgur
{
    using SNAGITLib;

    public class TemporaryImageProvider : ITemporaryImageProvider
    {
        private readonly ISnagIt snagitHost;

        public TemporaryImageProvider(ISnagIt snagitHost)
        {
            this.snagitHost = snagitHost;
        }
    }
}