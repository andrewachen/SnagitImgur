using System;

namespace SnagitImgur.Core
{
    public interface ITemporaryImageProvider
    {
        ITemporaryImage CreateTemporaryImage();
    }
}