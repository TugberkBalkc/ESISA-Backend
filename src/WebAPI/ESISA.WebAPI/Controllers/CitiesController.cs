using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCitiesByCountryId;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsById;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : CustomControllerBase
    {
        public CitiesController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
            
        }
        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCitiesAsync([FromQuery] GetAllCitiesQueryRequest getAllCitiesQueryRequest)
        {
            var response = await base._mediator.Send(getAllCitiesQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
        [HttpGet("GetAllCitiesByCountryId")]
        public async Task<IActionResult> GetAllCitiesByCountryIdAsync([FromQuery] GetAllCitiesByCountryIdQueryRequest getAllCitiesByCountryIdQueryRequest)
        {
            var response = await base._mediator.Send(getAllCitiesByCountryIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
