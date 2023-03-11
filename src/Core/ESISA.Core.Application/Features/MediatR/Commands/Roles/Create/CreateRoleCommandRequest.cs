using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Create
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public String RoleName { get; set; }

        public CreateRoleCommandRequest()
        {

        }

        public CreateRoleCommandRequest(string roleName)
        {
            RoleName = roleName;
        }
    }
}
