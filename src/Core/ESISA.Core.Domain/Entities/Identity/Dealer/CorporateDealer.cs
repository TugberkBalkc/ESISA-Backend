using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateDealer : EntityBase
    {
        public Guid DealerId { get; set; }
        public Guid SalesCategoryId { get; set; } = Guid.Parse(DefaultCategoryValues.DefaultCategoryId);
        public Guid AddressId { get; set; } = Guid.Parse(DefaultAddressValues.DefaultAddressId);

        public String CompanyName { get; set; }
        public String TaxIdentityNumber { get; set; }
        public CompanyType CompanyType { get; set; }

        public virtual Dealer Dealer { get; set; }
        public virtual Category Category { get; set; }
        public virtual Address Address { get; set; }


        public virtual ICollection<CorporateAdvert> CorporateAdverts { get; set; }

        public virtual ICollection<WholesaleAdvert> WholesaleAdverts { get; set; }

        public virtual ICollection<CorporateCustomerCorporateDealerComment> CorporateCustomerCorporateDealerComments { get; set; }

        public virtual ICollection<IndividualCustomerCorporateAdvertOrder> IndividualCustomerCorporateAdvertOrders { get; set; }
        public virtual ICollection<CorporateCustomerWholesaleAdvertOrder> CorporateCustomerWholesaleAdvertOrders { get; set; }

        public virtual ICollection<ProductDemand> ProductDemands { get; set; }
        public virtual ICollection<CategoryDemand> CategoryDemands { get; set; }
        public virtual ICollection<BrandDemand> BrandDemands { get; set; }

    }
}
