using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualCustomer : Person
    {
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<IndividualCustomerAddress> IndividualCustomerAddresses { get; set; }

        public virtual ICollection<IndividualCustomerCorporateAdvertComment> IndividualCustomerCorporateAdvertComments { get; set; }
        public virtual ICollection<IndividualCustomerCorporateAdvertFavorite> IndividualCustomerCorporateAdvertFavorites { get; set; }
        public virtual ICollection<IndividualCustomerCorporateAdvertVote> IndividualCustomerCorporateAdvertVotes { get; set; }

        public virtual ICollection<IndividualCustomerIndividualDealerComment> IndividualCustomerIndividualDealerComments { get; set; }
        public virtual ICollection<IndividualCustomerIndividualDealerVote> IndividualCustomerIndividualDealerVotes { get; set; }

        public virtual ICollection<IndividualCustomerIndividualAdvertFavorite> IndividualCustomerIndividualAdvertFavorites { get; set; }

        public virtual ICollection<IndividualCustomerCorporateAdvertOrder> IndividualCustomerCorporateAdvertOrders { get; set; }
    }
}
