using ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.AddAddress;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualStarters.GetAllIndividualStartersAddressesDetails;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualStarters.GetAllIndividualStartersAddressesDetails;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomerAddressController : CustomControllerBase
    {
        public IndividualCustomerAddressController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("AddAddressToIndividualCustomer")]
        public async Task<IActionResult> AddAddressToIndividualCustomerAsync([FromBody] AddAddressToIndividualCustomerCommandRequest addAddressToIndividualCustomerCommandRequest)
        {
            var response = await _mediator.Send(addAddressToIndividualCustomerCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetIndividualStartersAddressesDetails")]
        public async Task<IActionResult> GetIndividualStartersAddressesDetailsAsync([FromQuery] GetAllIndividualStartersAddressesDetailsQueryRequest getAllIndividualStartersAddressesDetailsQueryRequest)
        {
            var response = await _mediator.Send(getAllIndividualStartersAddressesDetailsQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
