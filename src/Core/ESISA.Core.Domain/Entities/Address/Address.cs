using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Address : EntityBase
    {
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }

        public String PostalCode { get; set; }
        public String Details { get; set; }


        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }


        public virtual ICollection<CorporateDealer> CorporateDealers { get; set; }
        public virtual ICollection<CorporateCustomerAddress> CorporateCustomerAddresses { get; set; }
        public virtual ICollection<IndividualCustomerAddress> IndividualCustomerAddresses { get; set; }
    }
}
