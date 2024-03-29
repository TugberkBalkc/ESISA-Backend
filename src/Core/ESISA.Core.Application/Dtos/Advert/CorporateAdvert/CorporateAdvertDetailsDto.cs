﻿using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.CorporateAdvert
{
    public class CorporateAdvertDetailsDto : AdvertDto
    {
        public bool IsCorporateAdvertActive { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public Guid CorporateAdvertCorporateDealerId { get; set; }
        public String CorporateAdvertCorporateDealerCompanyName { get; set; }


        public Guid CorporateAdvertProductId { get; set; }
        public String CorporateAdvertProductName { get; set; }

        public Guid CorporateAdvertProductCategoryId { get; set; }
        public String CorporateAdvertProductCategoryName { get; set; }

        public Guid CorporateAdvertProductBrandId { get; set; }
        public String CorporateAdvertProductBrandName { get; set; }

        public Guid CorporateAdvertPurchaseQuantityDiscountId { get; set; }
        public String CorporateAdvertPurchaseQuantityDiscountName { get; set; }
        public decimal CorporateAdvertPurchaseQuantityDiscountRate { get; set; }
        public DateTime CorporateAdvertPurchaseQuantityDiscountDeadline { get; set; }
        

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
        public decimal CorporateAdvertDiscountedUnitPrice 
        {
            get 
            {
                if (this.CorporateAdvertPurchaseQuantityDiscountRate != 0)
                    return PriceChangeUtility.ReducePriceByRate(this.CorporateAdvertUnitPrice, this.CorporateAdvertPurchaseQuantityDiscountRate);
                return this.CorporateAdvertUnitPrice;
            }
        }

        public int CorporateAdvertCommentsCount { get; set; }
        public int CorporateAdvertFavoritesCount { get; set; }

        public List<AdvertPhotoPathDto> AdvertPhotos { get; set; }
    }
}
