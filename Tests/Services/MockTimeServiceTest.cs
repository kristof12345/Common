using Common.Backend;
using System;
using Xunit;

namespace Common.Tests.Services
{
    public class MockTimeServiceTest
    {
        [Fact]
        public void NowTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var time = timeService.Now;

            // Assert
            Assert.Equal(new DateTime(1997, 8, 1), time.Date);
            Assert.Equal(12, time.Hour);
            Assert.Equal(35, time.Minute);
        }

        [Fact]
        public void TodayTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var date = timeService.Today;

            // Assert
            Assert.Equal(new DateTime(1997, 8, 1), date);
            Assert.Equal(TimeSpan.Zero, date.TimeOfDay);
        }

        [Fact]
        public void TomorrowTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var date = timeService.Tomorrow;

            // Assert
            Assert.Equal(new DateTime(1997, 8, 2), date);
            Assert.Equal(TimeSpan.Zero, date.TimeOfDay);
        }

        [Fact]
        public void YesterdayTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var date = timeService.Yesterday;

            // Assert
            Assert.Equal(new DateTime(1997, 7, 31), date);
            Assert.Equal(TimeSpan.Zero, date.TimeOfDay);
        }

        [Fact]
        public void FutureTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var time = timeService.Future(TimeSpan.FromHours(2));

            // Assert
            Assert.Equal(new DateTime(1997, 8, 1), time.Date);
            Assert.Equal(14, time.Hour);
            Assert.Equal(35, time.Minute);
        }

        [Fact]
        public void PastTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var time = timeService.Past(TimeSpan.FromHours(2));

            // Assert
            Assert.Equal(new DateTime(1997, 8, 1), time.Date);
            Assert.Equal(10, time.Hour);
            Assert.Equal(35, time.Minute);
        }

        [Fact]
        public void UntilTest()
        {
            // Arrange
            var timeService = new MockTimeService(new DateTime(1997, 8, 1, 12, 35, 44));

            // Act
            var time = timeService.Until(new DateTime(1997, 8, 1, 14, 37, 44));

            // Assert
            Assert.Equal(122, time.TotalMinutes);
            Assert.InRange(time.TotalHours, 2, 3);
        }
    }
}
