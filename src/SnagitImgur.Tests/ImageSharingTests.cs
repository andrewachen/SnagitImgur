using System;
using NUnit.Framework;
using TestStack.BDDfy;
using TestStack.BDDfy.Core;

namespace SnagitImgur.Tests
{
    [Story]
    public class ImageSharingTests
    {
        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
