using ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateBrandDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateCategoryDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateProductDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteBrandDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteCategoryDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteProductDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeBrandDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeCategoryDemand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeProductDemand;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandsController : CustomControllerBase
    {
        public DemandsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateBrandDemand")]
        public async Task<IActionResult> CreateBrandDemandAsync([FromBody] CreateBrandDemandCommandRequest createBrandDemandCommandRequest)
        {
            var response = await _mediator.Send(createBrandDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteBrandDemand")]
        public async Task<IActionResult> DeleteBrandDemandAsync([FromBody] DeleteBrandDemandCommandRequest deleteBrandDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteBrandDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteRangeBrandDemand")]
        public async Task<IActionResult> DeleteRangeBrandDemandAsync([FromBody] DeleteRangeBrandDemandCommandRequest deleteRangeBrandDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeBrandDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("CreateCategoryDemand")]
        public async Task<IActionResult> CreateCategoryDemandAsync([FromBody] CreateCategoryDemandCommandRequest createCategoryDemandCommand)
        {
            var response = await _mediator.Send(createCategoryDemandCommand);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteCategoryDemand")]
        public async Task<IActionResult> DeleteCategoryDemandAsync([FromBody] DeleteCategoryDemandCommandRequest deleteCategoryDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteCategoryDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteRangeCategoryDemand")]
        public async Task<IActionResult> DeleteRangeCategoryDemandAsync([FromBody] DeleteRangeCategoryDemandCommandRequest deleteRangeCategoryDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeCategoryDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("CreateProductDemand")]
        public async Task<IActionResult> CreateProductDemandAsync([FromBody] CreateProductDemandCommandRequest createProductDemandCommand)
        {
            var response = await _mediator.Send(createProductDemandCommand);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteProductDemand")]
        public async Task<IActionResult> DeleteProductDemandAsync([FromBody] DeleteProductDemandCommandRequest deleteProductDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteProductDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteRangeProductDemand")]
        public async Task<IActionResult> DeleteRangeProductDemandAsync([FromBody] DeleteRangeProductDemandCommandRequest deleteRangeProductDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeProductDemandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
