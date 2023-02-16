using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CompletedOrder : EntityBase
    {
        public Guid OrderId { get; set; }


        public virtual Order Order { get; set; }
    }
}
