using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCountries;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : CustomControllerBase
    {
        public CountriesController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }
        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountriesAsync([FromQuery] GetAllCountriesQueryRequest getAllCountriesQueryRequest)
        {
            var response = await base._mediator.Send(getAllCountriesQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
