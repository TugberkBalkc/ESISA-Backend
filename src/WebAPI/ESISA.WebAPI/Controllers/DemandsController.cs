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

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteBrandDemand")]
        public async Task<IActionResult> DeleteBrandDemandAsync([FromBody] DeleteBrandDemandCommandRequest deleteBrandDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteBrandDemandCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeBrandDemand")]
        public async Task<IActionResult> DeleteRangeBrandDemandAsync([FromBody] DeleteRangeBrandDemandCommandRequest deleteRangeBrandDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeBrandDemandCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateCategoryDemand")]
        public async Task<IActionResult> CreateCategoryDemandAsync([FromBody] CreateCategoryDemandCommandRequest createCategoryDemandCommand)
        {
            var response = await _mediator.Send(createCategoryDemandCommand);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteCategoryDemand")]
        public async Task<IActionResult> DeleteCategoryDemandAsync([FromBody] DeleteCategoryDemandCommandRequest deleteCategoryDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteCategoryDemandCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeCategoryDemand")]
        public async Task<IActionResult> DeleteRangeCategoryDemandAsync([FromBody] DeleteRangeCategoryDemandCommandRequest deleteRangeCategoryDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeCategoryDemandCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateProductDemand")]
        public async Task<IActionResult> CreateProductDemandAsync([FromBody] CreateProductDemandCommandRequest createProductDemandCommand)
        {
            var response = await _mediator.Send(createProductDemandCommand);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteProductDemand")]
        public async Task<IActionResult> DeleteProductDemandAsync([FromBody] DeleteProductDemandCommandRequest deleteProductDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteProductDemandCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeProductDemand")]
        public async Task<IActionResult> DeleteRangeProductDemandAsync([FromBody] DeleteRangeProductDemandCommandRequest deleteRangeProductDemandCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeProductDemandCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
