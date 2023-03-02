using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization
{
    public class UserRefreshToken : EntityBase
    {
        public Guid UserId { get; set; }
        public String RefreshTokenCode { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

        public virtual User User { get; set; }
    }
}
