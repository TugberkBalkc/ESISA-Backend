﻿using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class PaymentMethod : EntityBase
    {
        public String Name { get; set; }

    }
}
