using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Country : EntityBase
    {
        public String Name { get; set; }


        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
