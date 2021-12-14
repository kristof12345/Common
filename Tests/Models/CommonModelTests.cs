using System;
using Common.Application;
using Common.Backend;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Tests.Models
{
    public class CommonModelTests
    {
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
            var settings = new ServerSettings { BaseUrl = "url", Version="1.0", RenderMode="Server" };
            ServerSettings.Instance = settings;

            Assert.Equal("url", settings.BaseUrl);
            Assert.Equal("url", ServerSettings.Instance.BaseUrl);
            Assert.Equal("1.0", ServerSettings.Instance.Version);
            Assert.Equal("Server", ServerSettings.Instance.RenderMode);
        }

        [Fact]
        public void LoginRequestTest()
        {
            var request = new LoginRequest { Username="username", Password="password" };

            Assert.Equal("username@password", request.ToString());
        }

        [Fact]
        public void PasswordRequestTest()
        {
            var request = new ChangePasswordRequest { OldPassword = "oldpassword", NewPassword="newpassword" };

            Assert.Equal("oldpassword", request.OldPassword);
            Assert.Equal("newpassword", request.NewPassword);
        }

        [Fact]
        public void EmptyDateRangeTest()
        {
            var range = new DateRange();

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01&To=9999.12.31", range.ToString());
        }

        [Fact]
        public void DateRangeTest()
        {
            var range = new DateRange(new DateTime(2020,1,1), new DateTime(2021,8,7));

            Assert.Equal(new DateTime(2020, 1, 1), range.Start);
            Assert.Equal(new DateTime(2021, 8, 7), range.End);
            Assert.Equal("?From=2020.01.01&To=2021.08.07", range.ToString());
        }

        [Fact]
        public void AppTest()
        {
            App.Environment = "UnitTest";
            App.Url = "localhost";
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var serviceCollection = new ServiceCollection();
            App.Services = serviceCollection.BuildServiceProvider();

            Assert.Equal("UnitTest", App.Environment);
            Assert.Equal("localhost", App.Url);
            Assert.Equal("db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", App.TokenSettings.Secret);
            Assert.Equal(3000, App.TokenSettings.ExpireMinutes);
            Assert.Null(App.Services.GetService<TimeService>());
        }
    }
}