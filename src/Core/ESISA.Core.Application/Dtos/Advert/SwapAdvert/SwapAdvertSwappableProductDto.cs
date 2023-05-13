using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.SwapAdvert
{
    public class SwapAdvertSwappableProductDto
    {
        public Guid SwapAdvertSwappableProductId { get; set; }
        public DateTime SwapAdvertSwappableProductCreatedDate { get; set; }
        public DateTime SwapAdvertSwappableProductModifiedDate { get; set; }
        public bool SwapAdvertSwappableProductIsActive { get; set; }
        public bool SwapAdvertSwappableProductIsDeleted { get; set; }

        public Guid ProductId { get; set; }
        public Guid SwapAdvertId { get; set; }

        public SwapAdvertSwappableProductDto()
        {

        }

        public SwapAdvertSwappableProductDto(Guid swapAdvertSwappableProductId, DateTime swapAdvertSwappableProductCreatedDate, DateTime swapAdvertSwappableProductModifiedDate, bool swapAdvertSwappableProductIsActive, bool swapAdvertSwappableProductIsDeleted, Guid productId, Guid swapAdvertId)
        {
            SwapAdvertSwappableProductId = swapAdvertSwappableProductId;
            SwapAdvertSwappableProductCreatedDate = swapAdvertSwappableProductCreatedDate;
            SwapAdvertSwappableProductModifiedDate = swapAdvertSwappableProductModifiedDate;
            SwapAdvertSwappableProductIsActive = swapAdvertSwappableProductIsActive;
            SwapAdvertSwappableProductIsDeleted = swapAdvertSwappableProductIsDeleted;
            ProductId = productId;
            SwapAdvertId = swapAdvertId;
        }
    }
}
