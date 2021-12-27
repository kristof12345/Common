using System;
using Common.Application;
using Common.Backend;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Tests.Models
{
    public class CloneableTests
    {
        public class CloneableEntity : Cloneable<CloneableEntity>, IEntity<int>
        {
            public int Id { get; set; }

            public Name Name { get; set; }
        }

        [Fact]
        public void SimpleCopyTest()
        {
            // Arrange
            var a = new CloneableEntity { Id = 1, Name = new Name("A", "B") };

            // Act
            var b = a;
            b.Id = 2;
            b.Name.Firstname = "C";

            // Assert
            Assert.Equal(2, a.Id);
            Assert.Equal(2, b.Id);
            Assert.Equal("C B", a.Name.ToString());
            Assert.Equal("C B", b.Name.ToString());
        }

        [Fact]
        public void ShallowCopyTest()
        {
            // Arrange
            var a = new CloneableEntity { Id = 1, Name = new Name("A", "B") };

            // Act
            var b = a.ShallowCopy();
            b.Id = 2;
            b.Name.Firstname = "C";

            // Assert
            Assert.Equal(1, a.Id);
            Assert.Equal(2, b.Id);
            Assert.Equal("C B", a.Name.ToString());
            Assert.Equal("C B", b.Name.ToString());
        }
    }
}

