using ESISA.Core.Application.Dtos.Security.Authentication.Logins;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.LoginAsIndividualStarter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.LoginAsCorporateDealer
{
    public class LoginAsCorporateDealerCommandRequest : IRequest<LoginAsCorporateDealerCommandResponse>
    {
        public CorporateDealerLoginDto CorporateDealerLoginDto { get; set; }

        public LoginAsCorporateDealerCommandRequest()
        {

        }

        public LoginAsCorporateDealerCommandRequest(CorporateDealerLoginDto corporateDealerLoginDto)
        {
            CorporateDealerLoginDto = corporateDealerLoginDto;
        }
    }
}
