using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public String UserEmailAddress { get; set; }
        public String UserContactNumber { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; }
    }
}
