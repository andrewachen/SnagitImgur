using System;

namespace SnagitImgur.Snagit
{
    public interface ISnagitHost
    {
        ICapturedImage GetCapturedImage();
        void StartAsyncOutput();
        void FinishAsyncOutput(bool isSuccessful);
    }
}