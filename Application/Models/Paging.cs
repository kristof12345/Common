using System.Collections.Generic;

namespace Common.Application
{
    public class PagedResult<T>
    {
        public int PageCount { get; set; }

        public List<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

        public PagedResult(List<T> results, int count)
        {
            PageCount = (count + Span.PageSize - 1) / Span.PageSize;
            Results = results;
        }
    }

    public class Span
    {
        public static int PageSize { get; set; } = 9;

        public static readonly Span Default = new Span();

        public int Start { get; set; }

        public int Size { get; set; }

        public Span()
        {
            Start = 0;
            Size = PageSize;
        }

        public Span(int start, int size)
        {
            Start = start;
            Size = size;
        }

        public override string ToString()
        {
            return "?Start=" + Start + "&Size=" + Size;
        }
    }
}
