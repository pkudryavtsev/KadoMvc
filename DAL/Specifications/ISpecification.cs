using System;
using System.Linq.Expressions;
using ProductDb.DataClasses;

namespace DAL.Specifications
{
    public interface ISpecification<T> where T : BaseEntity
    {
        
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }

    }
}