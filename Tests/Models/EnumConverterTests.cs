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

            B,
            [EnumMember(Value = "Coconut")]
            C
        }

        [Fact]
        public void GetAttributeListTest()
        {
            var list = EnumExtensions.GetAttributeList<TestEnum>();
            Assert.Equal(3, list.Count);
            Assert.Equal("Apple", list[0]);
            Assert.Null(list[1]);
            Assert.Equal("Coconut", list[2]);
        }

        [Fact]
        public void GetAttributeValueTest()
        {
            var enumval = TestEnum.A;
            Assert.Equal("Apple", enumval.GetAttributeValue());
        }

        [Fact]
        public void GetAttributeValueEmptyTest()
        {
            var type = TestEnum.B;
            Assert.Equal("", type.GetAttributeValue());
        }

        [Fact]
        public void GetAttributeValueNullTest()
        {
            TestEnum? enumVar = null;
            Assert.Equal("", enumVar.GetAttributeValue());
        }

        [Fact]
        public void ParseEnumTest()
        {
            var value = EnumExtensions.GetValueFromAttribute<TestEnum>("Coconut");
            Assert.Equal(TestEnum.C, value);
        }

        [Fact]
        public void ParseInvalidEnumTest()
        {
            Assert.Throws<System.ArgumentException>(() => EnumExtensions.GetValueFromAttribute<TestEnum>("Banana"));
        }

        [Fact]
        public void ParseNotEnumTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => EnumExtensions.GetValueFromAttribute<string>("Banana"));
        }
    }
}
