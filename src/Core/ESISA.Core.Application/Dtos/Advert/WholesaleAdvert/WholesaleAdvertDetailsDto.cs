using ESISA.Core.Application.Dtos.Advert.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.WholesaleAdvert
{
    public class WholesaleAdvertDetailsDto : AdvertDto
    {
        public bool IsWholesaleAdvertActive { get; set; }

        public Guid WholesaleAdvertCorporateDealerId { get; set; }
        public String WholesaleAdvertCorporateDealerCompanyName { get; set; }

        public Guid WholesaleAdvertProductId { get; set; }
        public String WholesaleAdvertProductName { get; set; }

        public String WholesaleAdvertProductCategoryId { get; set; }
        public String WholesaleAdvertProductCategoryName { get; set; }

        public String WholesaleAdvertProductBrandId { get; set; }
        public String WholesaleAdvertProductBrandName { get; set; }

        public Guid WholesaleAdvertPurchaseQuantityDiscountId { get; set; }
        public String WholesaleAdvertPurchaseQuantityDiscountName { get; set; }
        public decimal WholesaleAdvertPurchaseQuantityDiscountRate { get; set; }
        public DateTime WholesaleAdvertPurchaseQuantityDiscountDeadline { get; set; }

        public int WholesaleAdvertMinimumPurchaseAmount { get; set; }
        public int WholesaleAdvertMaximumPurchaseAmount { get; set; }
        public decimal WholesaleAdvertPricePerUnit { get; set; }
        public decimal WholesaleAdvertDiscountedPricePerUnit { get; set; }
    }
}
