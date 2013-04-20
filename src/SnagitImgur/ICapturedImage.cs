using System;

namespace SnagitImgur
{
    public interface ICapturedImage : IDisposable
    {
        string FileName { get; }
    }
}