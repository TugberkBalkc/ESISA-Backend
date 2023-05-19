using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.RegisterAsCorporateCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.RegisterAsCorporateDealer
{
    public class RegisterAsCorporateDealerCommandRequest : IRequest<RegisterAsCorporateDealerCommandResponse>
    {
        public RegisterCorporateDealerDto RegisterCorporateDealerDto { get; set; }

        public RegisterAsCorporateDealerCommandRequest()
        {

        }

        public RegisterAsCorporateDealerCommandRequest(RegisterCorporateDealerDto registerCorporateDealerDto)
        {
            RegisterCorporateDealerDto = registerCorporateDealerDto;
        }
    }
}
