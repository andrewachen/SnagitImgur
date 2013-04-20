using System;

namespace SnagitImgur
{
    public interface ISnagitHost
    {
        ICapturedImage GetCapturedImage();
        void StartAsyncOutput();
        void FinishAsyncOutput(bool isSuccessful);
    }
}