using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class User : EntityBase
    {
        public String Email { get; set; }
        public String UserName { get; set; }
        public String ContactNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }

        public virtual RefreshToken RefreshToken { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Dealer Dealer { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
