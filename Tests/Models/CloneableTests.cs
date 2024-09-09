using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class CloneableTests
    {
        public class CloneableEntity : Cloneable<CloneableEntity>, IEntity<int>
        {
            public int Id { get; set; }

            public DbUser User { get; set; }
        }

        [Fact]
        public void SimpleCopyTest()
        {
            // Arrange
            var a = new CloneableEntity { Id = 1, User = new DbUser { Firstname = "A", Surname = "B" } };

            // Act
            var b = a;
            b.Id = 2;
            b.User.Firstname = "C";

            // Assert
            Assert.Equal(2, a.Id);
            Assert.Equal(2, b.Id);
            Assert.Equal("C", a.User.Firstname);
            Assert.Equal("B", a.User.Surname);
            Assert.Equal("C", b.User.Firstname);
            Assert.Equal("B", b.User.Surname);
        }

        [Fact]
        public void ShallowCopyTest()
        {
            // Arrange
            var a = new CloneableEntity { Id = 1, User = new DbUser { Firstname = "A", Surname = "B" } };

            // Act
            var b = a.ShallowCopy();
            b.Id = 2;
            b.User.Firstname = "C";

            // Assert
            Assert.Equal(1, a.Id);
            Assert.Equal(2, b.Id);
            Assert.Equal("C", a.User.Firstname);
            Assert.Equal("B", a.User.Surname);
            Assert.Equal("C", b.User.Firstname);
            Assert.Equal("B", b.User.Surname);
        }
    }
}