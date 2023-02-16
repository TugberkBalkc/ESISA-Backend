using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualCustomerCorporateAdvertOrder : EntityBase
    {
        public Guid OrderId { get; set; }
        public Guid CorporateDealerId { get; set; }
        public Guid IndividualCustomerId { get; set;}
        public Guid IndividualCustomerAddressId { get; set; }
  
        public decimal TotalPrice { get; set; }
        public decimal DiscountedTotalPrice { get; set; }


        public virtual Order Order { get; set; }
        public virtual CorporateDealer CorporateDealer { get; set; }
        public virtual IndividualCustomer IndividualCustomer { get; set; }
        public virtual IndividualCustomerAddress IndividualCustomerAddress { get; set; }

        public virtual ICollection<CorporateAdvertOrderItem> CorporateAdvertOrderItems { get; set; }
    }
}
