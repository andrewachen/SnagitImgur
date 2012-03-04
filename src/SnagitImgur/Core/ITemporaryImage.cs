using System;

namespace SnagitImgur.Core
{
    public interface ITemporaryImage : IDisposable
    {
        string Filename { get; }

        void Delete();
    }
}