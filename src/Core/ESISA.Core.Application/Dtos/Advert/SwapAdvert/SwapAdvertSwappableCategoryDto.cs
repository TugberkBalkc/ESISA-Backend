using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.SwapAdvert
{
    public class SwapAdvertSwappableCategoryDto
    {
        public Guid SwapAdvertSwappableCategoryId { get; set; }
        public DateTime SwapAdvertSwappableCategoryCreatedDate { get; set; }
        public DateTime SwapAdvertSwappableCategoryModifiedDate { get; set; }
        public bool SwapAdvertSwappableCategoryIsActive { get; set; }
        public bool SwapAdvertSwappableCategoryIsDeleted { get; set; }

        public Guid CategoryId { get; set; }
        public Guid SwapAdvertId { get; set; }

        public SwapAdvertSwappableCategoryDto()
        {

        }

        public SwapAdvertSwappableCategoryDto(Guid swapAdvertSwappableCategoryId, DateTime swapAdvertSwappableCategoryCreatedDate, DateTime swapAdvertSwappableCategoryModifiedDate, bool swapAdvertSwappableCategoryIsActive, bool swapAdvertSwappableCategoryIsDeleted, Guid categoryId, Guid swapAdvertId)
        {
            SwapAdvertSwappableCategoryId = swapAdvertSwappableCategoryId;
            SwapAdvertSwappableCategoryCreatedDate = swapAdvertSwappableCategoryCreatedDate;
            SwapAdvertSwappableCategoryModifiedDate = swapAdvertSwappableCategoryModifiedDate;
            SwapAdvertSwappableCategoryIsActive = swapAdvertSwappableCategoryIsActive;
            SwapAdvertSwappableCategoryIsDeleted = swapAdvertSwappableCategoryIsDeleted;
            CategoryId = categoryId;
            SwapAdvertId = swapAdvertId;
        }
    }
}
