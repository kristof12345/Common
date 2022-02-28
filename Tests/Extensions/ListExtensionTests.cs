using System;
using System.Collections.Generic;
using System.Linq;
using Common.Application;
using Xunit;

namespace Common.Tests.Extensions
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

        public class Unique : ILabeledValue, IEntity<int>
        {
            public int Id { get; set; }

            public decimal Value { get; set; }

            public string Label { get; set; }

            public string Color { get; set; }
        }

        public class Entity : IEntity<string>
        {
            public string Id { get; set; }

            public string Content { get; set; }
        }

        [Fact]
        public void GetByIdTest()
        {
            var list = new List<Entity>
            {
                new Entity { Id = "1", Content = "a" },
                new Entity { Id = "2", Content = "b" }
            };

            Assert.Equal("a", list.GetById("1").Content);
            Assert.Equal("b", list.GetById("2").Content);
            Assert.Null(list.GetById("3"));
        }

        [Fact]
        public void GetByContentTest()
        {
            var list = new List<Unique>
            {
                new Unique { Value = 1, Label = "a" },
                new Unique { Value = 2, Label = "b" }
            };

            Assert.Equal("a", list.GetById(1).Label);
            Assert.Equal("b", list.GetById(2).Label);
            Assert.Null(list.GetById(3));
            Assert.Equal(1, list.GetByContent("a").Id);
            Assert.Equal(2, list.GetByContent("b").Id);
            Assert.Null(list.GetByContent("c"));
        }

        [Fact]
        public void DateRangeFilterTest()
        {
            var list = new List<StockPrice>
            {
                new StockPrice { Date = new DateTime(2020,1,1), Volume=10 },
                new StockPrice { Date = new DateTime(2020,1,2), Volume=20 },
                new StockPrice { Date = new DateTime(2020,1,3), Volume=30 },
                new StockPrice { Date = new DateTime(2020,1,4), Volume=40 },
                new StockPrice { Date = new DateTime(2020,1,5), Volume=50 },
                new StockPrice { Date = new DateTime(2020,2,1), Volume=60 },
                new StockPrice { Date = new DateTime(2020,2,2), Volume=70 },
                new StockPrice { Date = new DateTime(2021,1,1), Volume=80 },
                new StockPrice { Date = new DateTime(2025,12,17), Volume=90 },
            };

            var filtered = list.DateFilter(new DateRange(new DateTime(2020, 1, 2), new DateTime(2020, 1, 4)));

            Assert.Equal(3, filtered.Count());
            Assert.Equal(20, filtered.First().Volume);
            Assert.Equal(40, filtered.Last().Volume);
        }

        [Fact]
        public void LatestDateTest()
        {
            var list = new List<StockPrice>
            {
                new StockPrice { Date = new DateTime(2020,1,1), Volume=10 },
                new StockPrice { Date = new DateTime(2020,1,2), Volume=20 },
                new StockPrice { Date = new DateTime(2020,1,3), Volume=30 },
                new StockPrice { Date = new DateTime(2020,1,4), Volume=40 },
                new StockPrice { Date = new DateTime(2020,1,5), Volume=50 },
                new StockPrice { Date = new DateTime(2020,2,1), Volume=60 },
                new StockPrice { Date = new DateTime(2020,2,2), Volume=70 },
                new StockPrice { Date = new DateTime(2021,1,1), Volume=80 },
                new StockPrice { Date = new DateTime(2025,12,17), Volume=90 },
            };

            var stock = list.Latest();

            Assert.Equal(new DateTime(2025, 12, 17), stock.Date);
            Assert.Equal(90, stock.Volume);
        }

        [Fact]
        public void LatestDateWithParameterTest()
        {
            var list = new List<StockPrice>
            {
                new StockPrice { Date = new DateTime(2020,1,1), Volume=10 },
                new StockPrice { Date = new DateTime(2020,1,2), Volume=20 },
                new StockPrice { Date = new DateTime(2020,1,3), Volume=30 },
                new StockPrice { Date = new DateTime(2020,1,4), Volume=40 },
                new StockPrice { Date = new DateTime(2020,1,5), Volume=50 },
                new StockPrice { Date = new DateTime(2020,2,1), Volume=60 },
                new StockPrice { Date = new DateTime(2020,2,2), Volume=70 },
                new StockPrice { Date = new DateTime(2021,1,1), Volume=80 },
                new StockPrice { Date = new DateTime(2025,12,17), Volume=90 },
            };

            var stock = list.Latest(new DateTime(2020, 5, 17));

            Assert.Equal(new DateTime(2020, 2, 2), stock.Date);
            Assert.Equal(70, stock.Volume);
        }

        [Fact]
        public void AsNotNullOriginalTest()
        {
            var list = new List<StockPrice>
            {
                new StockPrice { Date = new DateTime(2020,1,1), Volume=10 }
            };

            Assert.NotNull(list.AsNotNull());
            Assert.Single(list.AsNotNull());
        }

        [Fact]
        public void AsNotNullTest()
        {
            List<StockPrice> list = null;

            Assert.NotNull(list.AsNotNull());
            Assert.Empty(list.AsNotNull());
        }

        [Fact]
        public void SparseTest()
        {
            var original = new List<StockPrice>
            {
                new StockPrice { Date = new DateTime(2020,1,1), Volume=10 },
                new StockPrice { Date = new DateTime(2020,1,2), Volume=20 },
                new StockPrice { Date = new DateTime(2020,1,3), Volume=30 },
                new StockPrice { Date = new DateTime(2020,1,4), Volume=40 },
                new StockPrice { Date = new DateTime(2020,1,5), Volume=50 },
                new StockPrice { Date = new DateTime(2020,2,1), Volume=60 },
                new StockPrice { Date = new DateTime(2020,2,2), Volume=70 },
                new StockPrice { Date = new DateTime(2021,1,1), Volume=80 },
                new StockPrice { Date = new DateTime(2025,12,17), Volume=90 },
            };

            var list = original.Sparse(4).ToList();

            Assert.Equal(4, list.Count);
            Assert.Equal(10, list[0].Volume);
            Assert.Equal(40, list[1].Volume);
            Assert.Equal(70, list[2].Volume);
            Assert.Equal(90, list[3].Volume);
        }
    }

    public class StockPrice : ITemporal
    {
        public DateTime Date { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public long Volume { get; set; }
    }
}
