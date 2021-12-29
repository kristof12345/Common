using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Application;
using Common.Backend;
using Common.Web;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Tests.Network
{
    public class HttpExtensionTests
    {
        public class PostmanResponse<T>
        {
            public T args { get; set; }
            public T data { get; set; }
        }

        private const string url = "https://postman-echo.com/";

        [Fact]
        public async Task GetAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.GetAsJsonAsync("get", new Name("Firstname", "Surname"));
            var result = await response.Content.ReadAsAsync<PostmanResponse<Name>>();

            // Assert
            Assert.Equal("Firstname Surname", result.args.ToString());
        }

        [Fact]
        public async Task PostAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PostAsJsonAsync("post", new Name("Firstname", "Surname"));
            var result = await response.Content.ReadAsAsync<PostmanResponse<Name>>();

            // Assert
            Assert.Equal("Firstname Surname", result.data.ToString());
        }

        [Fact]
        public async Task PutAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PutAsJsonAsync("put", new Name("Firstname", "Surname"));
            var result = await response.Content.ReadAsAsync<PostmanResponse<Name>>();

            // Assert
            Assert.Equal("Firstname Surname", result.data.ToString());
        }

        [Fact]
        public async Task PatchAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PatchAsJsonAsync("patch", new Name("Firstname", "Surname"));
            var result = await response.Content.ReadAsAsync<PostmanResponse<Name>>();

            // Assert
            Assert.Equal("Firstname Surname", result.data.ToString());
        }
    }
}