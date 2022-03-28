using Common.Application;
using Xunit;

namespace Common.Tests.Services
{
    public class UtilsTests
    {
        [Fact]
        public void DeepCopyTest()
        {
            // Arrange
            var original = new AppUser();
            original.Id = "Original";

            // Act
            var clone = Utils.DeepCopy(original);
            clone.Id = "Clone";

            // Assert
            Assert.Equal("Original", original.Id);
            Assert.Equal("Clone", clone.Id);
        }
    }
}

