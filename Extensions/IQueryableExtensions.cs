using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace VetS.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnas)
        {
            if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnas.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnas[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnas[queryObj.SortBy]);
        }
    }
}
