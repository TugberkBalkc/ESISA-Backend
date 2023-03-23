using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndividualCustomerAdressesByIndividualCustomerId;
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
        [HttpGet("GetAllIndividualCustomerAdressByIndividualCustomerId")]
        public async Task<IActionResult> GetAllIndividualCustomerAdressByIndividualCustomerIdAsync([FromQuery] 
        GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest getAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest)
        {
            var response = await base._mediator.Send(getAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
