using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Backend;
using Hangfire;
using Xunit;

namespace Common.Tests.Services
{
    public class SchedulerServiceTest
    {
        [Fact]
        public void SingleApiCallTest()
        {
            // Arrange
            var scheduler = new SchedulerService(new TokenService(TokenHelper.Settings));

            // Act
            scheduler.AddSingleApiCall("url", HttpMethod.Get, TimeSpan.FromSeconds(5));
        }

        [Fact]
        public void RecurringApiCallTest()
        {
            // Arrange
            var scheduler = new SchedulerService(new TokenService(TokenHelper.Settings));

            // Act
            scheduler.AddRecurringApiCall("url", HttpMethod.Get, Cron.Daily());
        }

        [Fact]
        public async Task SendApiCallToInvalidUrlTest()
        {
            // Arrange
            var scheduler = new SchedulerService(new TokenService(TokenHelper.Settings));

            // Act
            var result = await scheduler.SendApiCall("url", HttpMethod.Get);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SendApiCallToValidUrlTest()
        {
            // Arrange
            var scheduler = new SchedulerService(new TokenService(TokenHelper.Settings));

            // Act
            var result = await scheduler.SendApiCall("https://www.google.hu/", HttpMethod.Get);

            // Assert
            Assert.True(result);
        }
    }
}