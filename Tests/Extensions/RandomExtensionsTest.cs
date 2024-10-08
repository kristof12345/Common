﻿using Common.Application;
using System;
using Xunit;

namespace Common.Tests.Extensions
{
    public class RandomExtensionsTest
    {
        [Fact]
        public void RandomDecimalTest()
        {
            // Arrange
            var random = new Random();

            // Act
            var value1 = random.Next(3.14m, 15.37m);
            var value2 = random.Next(3.14m, 15.37m);

            // Assert
            Assert.NotEqual(value1, value2);
            Assert.InRange(value1, 3.14m, 15.37m);
            Assert.InRange(value2, 3.14m, 15.37m);
        }

        [Fact]
        public void RandomDoubleTest()
        {
            // Arrange
            var random = new Random();

            // Act
            var value1 = random.Next(3.14, 15.37);
            var value2 = random.Next(3.14, 15.37);

            // Assert
            Assert.NotEqual(value1, value2);
            Assert.InRange(value1, 3.14, 15.37);
            Assert.InRange(value2, 3.14, 15.37);
        }

        [Fact]
        public void RandomNextDecimalTest()
        {
            // Arrange
            var random = new Random();

            // Act
            var value1 = random.NextDecimal();
            var value2 = random.NextDecimal();

            // Assert
            Assert.NotEqual(value1, value2);
            Assert.InRange(value1, 0, 1);
            Assert.InRange(value2, 0, 1);
        }
    }
}