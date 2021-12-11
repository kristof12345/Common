using System;
using Common.Application;
using Common.Backend;
using Xunit;

namespace Common.Tests.Services
{
    public class TimeServiceTest
    {
        [Fact]
        public void NowTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var time = timeService.Now;

            // Assert
            Assert.Equal(DateTime.UtcNow.Date, time.Date);
            Assert.Equal(DateTime.UtcNow.Hour, time.Hour);
            Assert.Equal(DateTime.UtcNow.Minute, time.Minute);
        }

        [Fact]
        public void TodayTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var date = timeService.Today;

            // Assert
            Assert.Equal(DateTime.Today, date);
            Assert.Equal(TimeSpan.Zero, date.TimeOfDay);
        }

        [Fact]
        public void TomorrowTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var date = timeService.Tomorrow;

            // Assert
            Assert.Equal(DateTime.Today.AddDays(1), date);
            Assert.Equal(TimeSpan.Zero, date.TimeOfDay);
        }

        [Fact]
        public void YesterdayTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var date = timeService.Yesterday;

            // Assert
            Assert.Equal(DateTime.Today.AddDays(-1), date);
            Assert.Equal(TimeSpan.Zero, date.TimeOfDay);
        }

        [Fact]
        public void FutureTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var time = timeService.Future(TimeSpan.FromHours(2));

            // Assert
            Assert.Equal(DateTime.UtcNow.Date, time.Date);
            Assert.Equal(DateTime.UtcNow.Hour + 2, time.Hour);
            Assert.Equal(DateTime.UtcNow.Minute, time.Minute);
        }

        [Fact]
        public void PastTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var time = timeService.Past(TimeSpan.FromHours(2));

            // Assert
            Assert.Equal(DateTime.UtcNow.Date, time.Date);
            Assert.Equal(DateTime.UtcNow.Hour - 2, time.Hour);
            Assert.Equal(DateTime.UtcNow.Minute, time.Minute);
        }

        [Fact]
        public void UntilTest()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var time = timeService.Until(DateTime.UtcNow.AddHours(30));

            // Assert
            Assert.InRange(time.TotalMinutes, 1750,1850);
            Assert.InRange(time.TotalHours, 29, 31);
        }
    }
}
