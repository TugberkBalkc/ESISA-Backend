using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Guid UserId { get; set; }


        public virtual User User { get; set; }

        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual IndividualCustomer IndividualCustomer { get; set; }
    }
}
