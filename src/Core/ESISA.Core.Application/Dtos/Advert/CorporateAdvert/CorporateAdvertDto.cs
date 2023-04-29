using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.CorporateAdverts
{
    public class CorporateAdvertDto : AdvertDto
    {
        public bool IsCorporateAdvertActive { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public Guid CorporateAdvertCorporateDealerId { get; set; }
        public Guid CorporateAdvertProductId { get; set; }
        public Guid CorporateAdvertPurchaseQuantityDiscountId { get; set; }

        public int CorporateAdvertStockAmount { get; set; }
        public bool IsCorporateAdvertOutOfStock
        {
            get
            {
                if (this.CorporateAdvertStockAmount == 0)
                    return true;

                return false;
            }
        }

        public decimal CorporateAdvertUnitPrice { get; set; }    
    }
}
