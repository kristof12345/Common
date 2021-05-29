using System;
using System.Linq.Expressions;

namespace Common.Application.Models
{
    public enum OrderDirection
    {
        Default,
        Ascending,
        Descending
    }

    public class Ordering<T>
    {
        public Expression<Func<T, object>> Expression { get; set; }

        public bool Descending { get; set; }

        public Ordering(Expression<Func<T, object>> expression, bool descending)
        {
            Expression = expression;
            Descending = descending;
        }
    }
}
