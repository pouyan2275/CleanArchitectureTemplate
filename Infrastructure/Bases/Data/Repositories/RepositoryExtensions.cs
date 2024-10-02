using Domain.Bases.Models.FilterParams;
using Domain.Bases.Models.SortParams;
using Infrastructure.Tools.Extensions;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Bases.Data.Repositories
{
    public static class RepositoryExtensions
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> queryable, List<FilterParam>? filterParams)
        {
            if (filterParams is null)
                return queryable;
            var filterString = "x => ";

            filterParams.ForEach(x =>
            {
                filterString += x.Operator switch
                {
                    FilterOperator.Contains => $" x.{x.Key}.ToString().Contains(\"{x.Value}\") and",
                    FilterOperator.IsNull => $" x.{x.Key} == null and",
                    FilterOperator.NotNull => $" x.{x.Key} != null and",
                    _ => $" x.{x.Key} {x.Operator.AttributeDescription()} \"{x.Value}\" and",
                };
            });
            filterString = filterString[..(filterString.Length - 3)];
            queryable = queryable.Where(filterString);
            return queryable;
        }
        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> queryable, List<SortParam>? sortParams)
        {
            if (sortParams is null)
                return queryable;
            var sortString = "";

            sortParams.ForEach(x => sortString += x.Key + (x.Desc ? " desc ," : " ,"));
            sortString = sortString[..(sortString.Length - 1)];
            queryable = queryable.OrderBy(sortString);
            return queryable;
        }
        public static IQueryable<TEntity> Page<TEntity>(this IQueryable<TEntity> queryable, int pageNumber, int pageSize)
        {
            var skipNumber = (pageNumber - 1) * pageSize;
            queryable = queryable.Skip(skipNumber).Take(pageSize);
            return queryable;
        }
    }
}
