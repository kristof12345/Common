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
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var scheduler = new SchedulerService(new TokenService());

            // Act
            Assert.Throws<InvalidOperationException>(() => scheduler.AddSingleApiCall("url", HttpMethod.Get, TimeSpan.FromSeconds(5)));
        }

        [Fact]
        public void RecurringApiCallTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var scheduler = new SchedulerService(new TokenService());

            // Act
            Assert.Throws<InvalidOperationException>(() => scheduler.AddRecurringApiCall("url", HttpMethod.Get, Cron.Daily()));
        }

        [Fact]
        public async Task SendApiCallToInvalidUrlTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var scheduler = new SchedulerService(new TokenService());

            // Act
            var result = await scheduler.SendApiCall("url", HttpMethod.Get);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SendApiCallToValidUrlTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var scheduler = new SchedulerService(new TokenService());

            // Act
            var result = await scheduler.SendApiCall("https://www.google.hu/", HttpMethod.Get);

            // Assert
            Assert.True(result);
        }
    }
}