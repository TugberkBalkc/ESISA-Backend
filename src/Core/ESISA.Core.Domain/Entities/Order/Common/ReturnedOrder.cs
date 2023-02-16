using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class ReturnedOrder : EntityBase
    {
        public Guid OrderId { get; set; }
        public OrderReturnReasonType ReturnReasonType { get; set; }
        public String ReasonDescripton { get; set; }


        public virtual Order Order { get; set; }
    }
}
