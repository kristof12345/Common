using System.Linq;
using System.Runtime.Serialization;
using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class EnumConverterTests
    {
        public enum TestEnum
        {
            [EnumMember(Value = "Apple")]
            A,
            [EnumMember(Value = "Banana")]
            B,
            [EnumMember(Value = "Coconut")]
            C
        }

        [Fact]
        public void EnumConverterGetAttributeListTest()
        {
            var list = EnumExtensions.GetAttributeList<TestEnum>();
            Assert.Equal(3, list.Count);
            Assert.Equal("Apple", list.First());
        }

        public enum TestEnum2
        {
            A,
            [EnumMember(Value = "Banana")]
            B,
            [EnumMember(Value = "Coconut")]
            C
        }

        [Fact]
        public void EnumConverterGetAttributeListTest2()
        {
            var list = EnumExtensions.GetAttributeList<TestEnum2>();
            Assert.Equal(3, list.Count);
            Assert.Null(list.First());
            Assert.Equal("Coconut", list.Last());
        }

        [Fact]
        public void EnumConverterValueTest3()
        {
            var type = TestEnum2.A;
            Assert.Equal("", type.GetAttributeValue());
        }

        [Fact]
        public void EnumParserTest2()
        {
            Assert.Throws<System.ArgumentException>(() => EnumExtensions.GetValueFromAttribute<TestEnum2>("Apple"));
        }

        [Fact]
        public void EnumConverterValueTest()
        {
            var enumval = UserType.Municipal;
            Assert.Equal("Municipal employee", enumval.GetAttributeValue());
        }

        [Fact]
        public void EnumConverterValueTest2()
        {
            var type = UserType.Government;
            Assert.Equal("Government employee", type.GetAttributeValue());
        }

        [Fact]
        public void EnumParserTest()
        {
            var value = EnumExtensions.GetValueFromAttribute<UserType>("Temporary worker");
            Assert.Equal(UserType.Worker, value);
        }
    }
}
