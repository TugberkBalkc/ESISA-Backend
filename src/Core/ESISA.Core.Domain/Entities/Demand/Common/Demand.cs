using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Demand : EntityBase
    {
        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }

        public virtual CorporateDealer  CorporateDealer { get; set; }
    }
}
