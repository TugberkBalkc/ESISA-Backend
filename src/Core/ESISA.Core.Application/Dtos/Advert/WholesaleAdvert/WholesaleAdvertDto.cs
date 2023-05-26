using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.WholesaleAdvert
{
    public class WholesaleAdvertDto : AdvertDto
    {
        public Guid WholesaleAdvertId { get; set; }
        public bool IsWholesaleAdvertActive { get; set; }

        public Guid WholesaleAdvertCorporateDealerId { get; set; }
        public Guid WholesaleAdvertProductId { get; set; }
        public Guid WholesaleAdvertPurchaseQuantityDiscountId { get; set; }

        public int WholesaleAdvertMinimumPurchaseAmount { get; set; }
        public int WholesaleAdvertMaximumPurchaseAmount { get; set; }
        public decimal WholesaleAdvertPricePerUnit { get; set; }
        public decimal WholesaleAdvertDiscountedPricePerUnit { get; set; }

        public int WholesaleAdvertStockAmount { get; set; }
    }
}
