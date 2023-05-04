using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllAdresses;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : CustomControllerBase
    {
        public AdressController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpGet("GetAllAdresses")]
        public async Task<IActionResult> GetAllAdressesAsync([FromQuery] GetAllAdressesQueryRequest getAllAdressesQueryRequest)
        {
            var response = await base._mediator.Send(getAllAdressesQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
