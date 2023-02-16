using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Dealer : EntityBase
    {
        public Guid UserId { get; set; }
        
        
        public virtual User User { get; set; }

        public virtual CorporateDealer CorporateDealer { get; set; }
        public virtual IndividualDealer IndividualDealer { get; set; }
        
    }
}
