using Common.Application;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            var response = await client.GetAsJsonAsync("get", new DbUser { Firstname = "Firstname", Surname = "Surname" });
            var result = await response.Content.ReadAsAsync<PostmanResponse<DbUser>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Firstname Surname", result.args.Name);
        }

        [Fact]
        public async Task PostAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PostAsJsonAsync("post", new DbUser { Firstname = "Firstname", Surname = "Surname" });
            var result = await response.Content.ReadAsAsync<PostmanResponse<DbUser>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Firstname Surname", result.data.Name);
        }

        [Fact]
        public async Task PutAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PutAsJsonAsync("put", new DbUser { Firstname = "Firstname", Surname = "Surname" });
            var result = await response.Content.ReadAsAsync<PostmanResponse<DbUser>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Firstname Surname", result.data.Name);
        }

        [Fact]
        public async Task PatchAsJsonTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PatchAsJsonAsync("patch", new DbUser { Firstname = "Firstname", Surname = "Surname" });
            var result = await response.Content.ReadAsAsync<PostmanResponse<DbUser>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Firstname Surname", result.data.Name);
        }

        [Fact]
        public async Task PostTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PostAsync("post");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PutTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PutAsync("put");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PatchTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.PatchAsync("patch");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task HeadTest()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri(url) };

            // Act
            var response = await client.HeadAsync("head");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}