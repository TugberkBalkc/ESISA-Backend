using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class RefreshToken : EntityBase
    {
        public Guid UserId { get; set; }
        public String Token { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual User User { get; set; }
    }
}
