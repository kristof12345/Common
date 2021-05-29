using System.Collections.Generic;
using System.Linq;

namespace Common.Application.Extensions
{
    public static class ListExtensions
    {
        public static bool IsDistinct<T>(this IEnumerable<T> list)
        {
            return list.Count() == list.Distinct().Count();
        }

        public static bool ContainsAll<T>(this IEnumerable<T> list, IEnumerable<T> subset)
        {
            return !subset.Except(list).Any();
        }

        public static List<T> Except<T>(this IEnumerable<T> list, T item)
        {
            return list.Except(new List<T> { item }).ToList();
        }

        public static bool Empty<T>(this IEnumerable<T> list)
        {
            return !list.Any();
        }

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        {
            return self.Select((item, index) => (item, index));
        }

        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static List<T> From<T>(T item)
        {
            return Enumerable.Repeat(item, 1).ToList();
        }
    }
}
