using System;
using System.Linq.Expressions;
using ProductDb.DataClasses;

namespace DAL.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {

        public Expression<Func<T, bool>> Criteria { get; protected set; }

        public Expression<Func<T, object>> OrderBy { get; protected set; }

        public Expression<Func<T, object>> OrderByDescending { get; protected set; }

        public int Take { get; protected set; }

        public int Skip { get; protected set; }

    }
}