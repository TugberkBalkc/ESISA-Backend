using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Paging.Extensions
{
    public static class IQueryablePaginateExtension
    {
        public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            int totalCount = source.Count();

            List<T> items = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Paginate<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = items,
                TotalPageCount = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
    }
}
