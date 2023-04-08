using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
        public bool UserIsActive { get; set; }
        public bool UserIsDeleted { get; set; }

        public String UserEmail { get; set; }
        public String UserName { get; set; }
        public String UserContactNumber { get; set; }
        public String UserPassword { get; set; }
    }
}
