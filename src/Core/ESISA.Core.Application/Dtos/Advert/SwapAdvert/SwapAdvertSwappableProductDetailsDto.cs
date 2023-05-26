using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.SwapAdvert
{
    public class SwapAdvertSwappableProductDetailsDto
    {
        public Guid SwapAdvertSwappableProductId { get; set; }
        public DateTime SwapAdvertSwappableProductCreatedDate { get; set; }
        public DateTime SwapAdvertSwappableProductModifiedDate { get; set; }
        public bool SwapAdvertSwappableProductIsActive { get; set; }
        public bool SwapAdvertSwappableProductIsDeleted { get; set; }

        public Guid ProductId { get; set; }
        public String ProductName { get; set; }
     
        public Guid ProductBrandId { get; set; }
        public String ProductBrandName { get; set; }

        public Guid SwapAdvertId { get; set; }
    }
}
