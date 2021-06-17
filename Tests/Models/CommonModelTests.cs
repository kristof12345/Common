using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class CommonModelTests
    {
        [Fact]
        public void AddressTest()
        {
            var address = new Address { City = "New York", Street = "Main Street", Number = 5 };

            Assert.Equal("New York, Main Street 5", address.ToString());
        }

        [Fact]
        public void NameTest()
        {
            var name = new Name { Surname = "Denem", Firstname = "Tom" };

            Assert.Equal("Tom Denem", name.ToString());
        }

        [Fact]
        public void EmptyNameToStringTest()
        {
            var name = new Name();

            Assert.Equal(" ", name.ToString());
        }

        [Fact]
        public void ServerSettingsTest()
        {
            var settings = new ServerSettings { BaseUrl = "url" };
            ServerSettings.Instance = settings;

            Assert.Equal("url", settings.BaseUrl);
            Assert.Equal("url", ServerSettings.Instance.BaseUrl);
        }
    }
}