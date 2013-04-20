using System;

namespace SnagitImgur.Snagit
{
    public interface ICapturedImage : IDisposable
    {
        string FileName { get; }
    }
}