//using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndividualCustomerAdressesByIndividualCustomerId;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndCAddressesByIndCId;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetIndCAddressesDetailsByIndCId;
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
        GetAllIndCAddressesByIndCIdQueryRequest getAllIndCAddressesByIndCIdQueryRequest)
        {
            var response = await base._mediator.Send(getAllIndCAddressesByIndCIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetIndividualCustomerAdressDetailsByIndividualCustomerId")]
        public async Task<IActionResult> GetIndividualCustomerAdressDetailsByIndividualCustomerIdAsync([FromQuery]
        GetIndCAddressesDetailsByIndCIdQueryRequest getIndCAddressesDetailsByIndCIdQueryRequest)
        {
            var response = await base._mediator.Send(getIndCAddressesDetailsByIndCIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
