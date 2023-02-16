using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class City : EntityBase
    {
        public Guid CountryId { get; set; }
        public String Name { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
