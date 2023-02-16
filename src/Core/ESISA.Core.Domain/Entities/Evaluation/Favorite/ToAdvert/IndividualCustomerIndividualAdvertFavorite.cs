using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualCustomerIndividualAdvertFavorite : EntityBase
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualAdvertId { get; set; }


        public virtual IndividualCustomer IndividualCustomer { get; set; }
        public virtual IndividualAdvert IndividualAdvert { get; set; }
    }
}
