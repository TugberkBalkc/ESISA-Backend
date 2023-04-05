using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.RegisterAsIndividualStarter
{
    public class RegisterAsIndividualStarterCommandRequest : IRequest<RegisterAsIndividualStarterCommandResponse>
    {
        public RegisterIndividualStarterDto RegisterIndividualStarterDto { get; set; }

        public RegisterAsIndividualStarterCommandRequest()
        {

        }

        public RegisterAsIndividualStarterCommandRequest(RegisterIndividualStarterDto registerIndividualStarterDto)
        {
            RegisterIndividualStarterDto = registerIndividualStarterDto;
        }
    }
}
