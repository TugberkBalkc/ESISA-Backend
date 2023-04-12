using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
   
    public class Discount : EntityBase
    {
        public String Description { get; set; }
        public decimal Rate { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCombinable { get; set; }
    }
}
