using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateCustomer : EntityBase
    {
        public Guid CustomerId { get; set; }

        public String CompanyName { get; set; }
        public String TaxIdentityNumber { get; set; }
        public CompanyType CompanyType { get; set; }


        public virtual Customer Customer { get; set; }

        public virtual ICollection<CorporateCustomerAddress> CorporateCustomerAddresses { get; set; }

        public virtual ICollection<CorporateCustomerWholesaleAdvertComment> CorporateCustomerWholesaleAdvertComments { get; set; }
        public virtual ICollection<CorporateCustomerWholesaleAdvertFavorite> CorporateCustomerWholesaleAdvertFavorites { get; set; }
        public virtual ICollection<CorporateCustomerWholesaleAdvertVote> CorporateCustomerWholesaleAdvertVotes { get; set; }

        public virtual ICollection<CorporateCustomerCorporateDealerComment> CorporateCustomerCorporateDealerComments { get; set; }

        public virtual ICollection<CorporateCustomerWholesaleAdvertOrder> CorporateCustomerWholesaleAdvertOrders { get; set; }
    }
}
