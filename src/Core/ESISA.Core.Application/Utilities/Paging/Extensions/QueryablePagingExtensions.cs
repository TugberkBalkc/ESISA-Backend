using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Paging.Extensions
{
    public static class QueryablePagingExtensions
    {
        public static IQueryable<T> ToPaginate<T>(this IQueryable<T> query, int pageSize, int pageIndex)
        {
            int count  = query.Count();

            int totalPageAmount = (int) Math.Ceiling( (decimal) (count / pageSize));

            CheckNotEmptyAccuracy(count);
            CheckTotalPageAmountAndPageIndexAccuracy(totalPageAmount, pageIndex);
            CheckPageSizeAndCountAccuracy(totalPageAmount, pageSize);

            if (pageIndex == 0)
                query = query.Take(pageSize);

            query = query.Skip(pageSize * pageIndex).Take(pageSize);

            return query;
        }

        private static void CheckTotalPageAmountAndPageIndexAccuracy(int totalPageAmount, int pageIndex)
        {
            if (pageIndex > totalPageAmount)
                throw new ArgumentException("Page Index Is Out Of Total Page Size");
        }

        private static void CheckPageSizeAndCountAccuracy(int count, int pageSize)
        {
            if (pageSize >= count)
                throw new ArgumentException("Page Size Cannot Greater Than Or Equal To Queryable's Count To Paging");
        }
        
        private static void CheckNotEmptyAccuracy(int count)
        {
            if (count == 0)
                throw new ArgumentException("Queryable Is Empty");
        }
    }
}
