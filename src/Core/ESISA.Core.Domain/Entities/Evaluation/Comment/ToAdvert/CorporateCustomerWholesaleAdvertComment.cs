﻿using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateCustomerWholesaleAdvertComment : EntityBase
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }


        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual WholesaleAdvert WholesaleAdvert { get; set; }
    }
}
