using ESISA.Core.Application.Dtos.Security.Authentication.Logins;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.LoginAsIndividualStarter
{
    public class LoginAsIndividualStarterCommandRequest : IRequest<LoginAsIndividualStarterCommandResponse>
    {
        public StarterLoginDto StarterLoginDto { get; set; }

        public LoginAsIndividualStarterCommandRequest()
        {

        }

        public LoginAsIndividualStarterCommandRequest(StarterLoginDto starterLoginDto)
        {
            StarterLoginDto = starterLoginDto;
        }
    }
}
