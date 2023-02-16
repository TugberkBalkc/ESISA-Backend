using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class District : EntityBase
    {
        public Guid CityId { get; set; }
        public String Name { get; set; }

        public virtual City City { get; set; }


        public virtual ICollection<Address> Addresses { get; set; }
    }
}
