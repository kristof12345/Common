using Common.Application;
using Common.Backend;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Common.Tests.Models
{
    public class CommonModelTests
    {
        [Fact]
        public void ServerSettingsTest()
        {
            var settings = new ServerSettings { BaseUrl = "url", Version = "1.0", RenderMode = "Server" };
            ServerSettings.Instance = settings;

            Assert.Equal("url", settings.BaseUrl);
            Assert.Equal("url", ServerSettings.Instance.BaseUrl);
            Assert.Equal("1.0", ServerSettings.Instance.Version);
            Assert.Equal("Server", ServerSettings.Instance.RenderMode);
        }

        [Fact]
        public void LoginRequestTest()
        {
            var request = new LoginRequest { Username = "username", Password = "password" };

            Assert.Equal("username@password", request.ToString());
        }

        [Fact]
        public void PasswordRequestTest()
        {
            var request = new ChangePasswordRequest { OldPassword = "oldpassword", NewPassword = "newpassword" };

            Assert.Equal("oldpassword", request.OldPassword);
            Assert.Equal("newpassword", request.NewPassword);
        }

        [Fact]
        public void AppTest()
        {
            App.Environment = "UnitTest";
            App.Url = "localhost";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<TokenSettings>(s => TokenHelper.Settings);
            serviceCollection.AddScoped<ITokenService, TokenService>();
            App.Services = serviceCollection.BuildServiceProvider();

            Assert.Equal("UnitTest", App.Environment);
            Assert.Equal("localhost", App.Url);
            Assert.NotNull(App.Services.GetService<ITokenService>());
            Assert.Null(App.Services.GetService<TimeService>());
        }

        [Fact]
        public void AppUserTest()
        {
            var user = new AppUser { Id = "username", Name = "User Name" };

            Assert.Equal("username", user.Id);
            Assert.Equal("User Name", user.Name.ToString());
        }

        [Fact]
        public void TemporalValueTest()
        {
            var temp = new TemporalValue { Value = 40, Date = DateTime.Today };

            Assert.Equal(40, temp.Value);
            Assert.Equal(DateTime.Today, temp.Date);
        }
    }
}