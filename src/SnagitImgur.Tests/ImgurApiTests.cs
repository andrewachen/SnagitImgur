using System.IO;
using NUnit.Framework;
using FluentAssertions;

namespace SnagitImgur.Tests
{
    [TestFixture]
    public class ImgurApiTests
    {
        private const string TestClientId = "55e8632abd0ad09";

        [Test]
        public async void UnderTest_Scenario_ExpectedResult()
        {
            var imgur = new Imgur(TestClientId);
            string path = Path.GetFullPath(@".\snagitimgur.png");
            var result = await imgur.UploadAsync(path);
            result.Link.Should().NotBeNullOrEmpty();
        }
    }
}