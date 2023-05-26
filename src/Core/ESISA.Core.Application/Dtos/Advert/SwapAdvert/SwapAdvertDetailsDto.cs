using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.SwapAdvert
{
    public class SwapAdvertDetailsDto : AdvertDto
    {
        public bool IsSwapAdvertActive { get; set; }
        public bool IsSwapAdvertSwapped
        {
            get
            {
                return !this.IsSwapAdvertActive;
            }
        }

        public Guid SwapAdvertId { get; set; }
        public Guid SwapAdvertIndividualDealerId { get; set; }
        public String SwapAdvertIndividualDealerFirstName { get; set; }
        public String SwapAdvertIndividualDealerLastName { get; set; }
        public Guid SwapAdvertProductId { get; set; }
        public String SwapAdvertProductName { get; set; }
        public String SwapAdvertProductCategoryId { get; set; }
        public String SwapAdvertProductCategoryName { get; set; }
        public String SwapAdvertProductBrandId { get; set; }
        public String SwapAdvertProductBrandName { get; set; }

        public ProductConditionType SwapAdvertProductConditionType { get; set; }

        public List<SwapAdvertSwappableCategoryDetailsDto> SwapAdvertSwappableCategories { get; set; }
        public List<SwapAdvertSwappableProductDetailsDto> SwapAdvertSwappableProducts { get; set; }
    }
}
