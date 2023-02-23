using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Paging
{
    public interface IPaginate<T>
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }
        int TotalPageCount { get; set; }
        IList<T> Items { get; set; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
