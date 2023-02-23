using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Paging
{
    public class Paginate<T> : IPaginate<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPageCount { get; set; }

        public IList<T> Items { get; set; }

        public bool HasPrevious => PageIndex > 0;

        public bool HasNext => PageIndex + 1 < TotalPageCount;

        public Paginate()
        {
            Items = new List<T>();
        }

        public Paginate(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;

            if (source is IQueryable<T> queryable)
            {
                TotalCount = queryable.Count();
                Items = queryable.Skip(PageIndex * PageSize).Take(PageSize).ToList();
            }
            else
            {
                T[] enumerable = source as T[] ?? source.ToArray();
                TotalCount = enumerable.Count();
                Items = enumerable.Skip(PageIndex * PageSize).Take(PageSize).ToList();
            }

            TotalPageCount = (int)Math.Ceiling(TotalCount / (double)pageSize);
        }
    }
}
