using Common.Application;
using Common.Backend;
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

        [Fact]
        public void AppTest()
        {
            App.Environment = "UnitTest";
            App.Url = "localhost";
            App.TokenSettings = new TokenSettings { Secret = "secret", ExpireMinutes = 120 };

            Assert.Equal("UnitTest", App.Environment);
            Assert.Equal("localhost", App.Url);
            Assert.Equal("secret", App.TokenSettings.Secret);
            Assert.Equal(120, App.TokenSettings.ExpireMinutes);
        }
    }
}