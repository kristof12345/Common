using System;
using System.Linq.Expressions;

namespace Common.Backend;

public interface ISearchFilter<T>
{
    public Expression<Func<T, bool>> CreateFilterExpression();
}