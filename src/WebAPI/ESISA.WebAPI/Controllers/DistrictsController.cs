using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCitiesByCountryId;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistricts;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistrictsByCityId;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : CustomControllerBase
    {
        public DistrictsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpGet("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistricts([FromQuery] GetAllDistrictsQueryRequest getAllDistrictsQueryRequest)
        {
            var response = await base._mediator.Send(getAllDistrictsQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllDistrictsByCityId")]
        public async Task<IActionResult> GetAllDistrictsByCityIdAsync([FromQuery] GetAllDistrictsByCityIdQueryRequest getAllDistrictsByCityIdQueryRequest)
        {
            var response = await base._mediator.Send(getAllDistrictsByCityIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
