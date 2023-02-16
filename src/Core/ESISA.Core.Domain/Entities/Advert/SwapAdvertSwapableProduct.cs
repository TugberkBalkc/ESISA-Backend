using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class SwapAdvertSwapableProduct : EntityBase
    {
        public Guid SwapAdvertId { get; set; }
        public Guid ProductId { get; set; }


        public virtual SwapAdvert SwapAdvert { get; set; }
        public virtual Product Product { get; set; }
    }
}
