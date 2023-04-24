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
        public Guid CorporateDealerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PurchaseQuantityDiscountId { get; set; } = Guid.Parse(DefaultDiscountValues.DefaultPurchaseQuantityDiscountId);

        public int StockAmount { get; set; }
        public decimal UnitPrice { get; set; }

        public CorporateAdvertDto()
        {

        }

        public CorporateAdvertDto(Guid advertId, Guid corporateDealerId, Guid productId, Guid purchaseQuantityDiscountId, int stockAmount, decimal unitPrice)
        {
            AdvertId = advertId;
            CorporateDealerId = corporateDealerId;
            ProductId = productId;
            PurchaseQuantityDiscountId = purchaseQuantityDiscountId;
            StockAmount = stockAmount;
            UnitPrice = unitPrice;
        }
    }
}
