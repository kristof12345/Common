using System.Collections.Generic;
using System.Linq;
using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class ListExtensionTests
    {
        [Fact]
        public void EmptyListTest()
        {
            var list = new List<string>();

            Assert.True(list.Empty());

            list.Add("Apple");

            Assert.False(list.Empty());
        }

        [Fact]
        public void IsDistinctTest()
        {
            var list1 = new List<string> { "apple" };
            var list2 = new List<string> { "apple", "banana", "orange" };
            var list3 = new List<string> { "apple", "banana", "orange", "apple" };
            var list4 = new List<string> { "apple", "plum", "plum" };
            var list5 = new List<string>();

            Assert.True(list1.IsDistinct());
            Assert.True(list2.IsDistinct());
            Assert.False(list3.IsDistinct());
            Assert.False(list4.IsDistinct());
            Assert.True(list5.IsDistinct());
        }

        [Fact]
        public void ContainsAllTest()
        {
            var list = new List<string> { "apple", "banana", "orange" };

            var list1 = new List<string> { "apple" };
            var list2 = new List<string> { "apple", "banana", "orange" };
            var list3 = new List<string> { "apple", "banana", "orange", "plum" };
            var list4 = new List<string> { "apple", "plum" };

            Assert.True(list.ContainsAll(list));
            Assert.True(list.ContainsAll(list1));
            Assert.True(list.ContainsAll(list2));
            Assert.False(list.ContainsAll(list3));
            Assert.False(list.ContainsAll(list4));
        }

        [Fact]
        public void ExceptTest()
        {
            var list = new List<string> { "apple", "banana", "orange" };

            Assert.Equal(2, list.Except("banana").Count());
            Assert.Equal(3, list.Count());
            Assert.Equal(3, list.Except("asd").Count());
        }

        [Fact]
        public void FromTest()
        {
            var list = ListExtensions.From("apple");

            Assert.Single(list);
            Assert.Equal("apple", list.Single());
        }

        [Fact]
        public void WithIndexTest()
        {
            var list = new List<string> { "apple", "banana", "orange" }.WithIndex();
            var (item, index) = list.Last();

            Assert.Equal(3, list.Count());
            Assert.Equal(2, index);
            Assert.Equal("orange", item);
        }

        [Fact]
        public void SwapTest()
        {
            var list = new List<string> { "apple", "banana", "orange" };
            list.Swap(0, 2);

            Assert.Equal(3, list.Count);
            Assert.Equal("orange", list.First());
            Assert.Equal("apple", list.Last());
        }

        [Fact]
        public void SwapBackTest()
        {
            var list = new List<string> { "apple", "banana", "orange" };
            list.Swap(0, 2);
            list.Swap(0, 2);

            Assert.Equal(3, list.Count);
            Assert.Equal("apple", list.First());
            Assert.Equal("orange", list.Last());
        }

        [Fact]
        public void SwapInPlaceTest()
        {
            var list = new List<string> { "apple", "banana", "orange" };
            list.Swap(0, 0);

            Assert.Equal(3, list.Count);
            Assert.Equal("apple", list.First());
            Assert.Equal("orange", list.Last());
        }

        public class Unique : IUnique
        {
            public int Id { get; set; }

            public string Content { get; set; }
        }

        [Fact]
        public void GetByContentTest()
        {
            var list = new List<Unique>
            {
                new Unique { Id = 1, Content = "a" },
                new Unique { Id = 2, Content = "b" }
            };

            Assert.Equal("a", list.GetById(1).Content);
            Assert.Equal("b", list.GetById(2).Content);
            Assert.Null(list.GetById(3));
            Assert.Equal(1, list.GetByContent("a").Id);
            Assert.Equal(2, list.GetByContent("b").Id);
            Assert.Null(list.GetByContent("c"));
        }
    }
}
