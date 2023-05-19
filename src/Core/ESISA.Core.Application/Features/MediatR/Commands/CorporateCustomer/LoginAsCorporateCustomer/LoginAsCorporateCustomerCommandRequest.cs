using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication.Logins;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.LoginAsCorporateCustomer
{
    public class LoginAsCorporateCustomerCommandRequest : IRequest<LoginAsCorporateCustomerCommandResponse>
    {
        public CorporateCustomerLoginDto CorporateCustomerLoginDto { get; set; }

        public LoginAsCorporateCustomerCommandRequest()
        {

        }

        public LoginAsCorporateCustomerCommandRequest(CorporateCustomerLoginDto corporateCustomerLoginDto)
        {
            CorporateCustomerLoginDto = corporateCustomerLoginDto;
        }
    }
}
