using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Update;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetAll;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetAllDetails;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetByDynamic;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByBrandContains;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByCategoryNameContains;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByNameContains;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        public ProductsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            var response = await base._mediator.Send(createProductCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync([FromBody] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var response = await base._mediator.Send(deleteProductCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeProduct")]
        public async Task<IActionResult> DeleteRangeProductAsync([FromBody] DeleteRangeProductCommandRequest deleteRangeProductCommandRequest)
        {
            var response = await base._mediator.Send(deleteRangeProductCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            var response = await base._mediator.Send(updateProductCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsyc([FromQuery] GetAllProductsQueryRequest getAllProductsQueryRequest) 
        {
            var response = await base._mediator.Send(getAllProductsQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("GetProductDynamicQuery")]
        public async Task<IActionResult> GetProductDynamicQueryAsync([FromBody] GetByDynamicProductQueryRequest getByDynamicProductQueryRequest)
        {
            var response = await base._mediator.Send(getByDynamicProductQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllProductsDetails")]
        public async Task<IActionResult> GetAllProductsDetailsAsync([FromQuery] GetAllDetailsProductQueryRequest getAllDetailsProductQueryRequest)
        {
            var response = await base._mediator.Send(getAllDetailsProductQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetDetailsNameContains")]
        public async Task<IActionResult> GetDetailsNameContainsAsync([FromQuery] GetDetailsByNameContainsProductQueryRequest getDetailsByNameContainsProductQueryRequest)
        {
            var response = await base._mediator.Send(getDetailsByNameContainsProductQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetDetailsByCategoryNameContains")]
        public async Task<IActionResult> GetDetailsByCategoryNameContains([FromQuery] GetDetailsByCategoryNameProductQueryRequest getDetailsByCategoryNameProductQueryRequest)
        {
            var response = await base._mediator.Send(getDetailsByCategoryNameProductQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetDetailsByBrandNameContains")]
        public async Task<IActionResult> GetDetailsByBrandNameContainsAsync([FromQuery] GetDetailsByBrandNameContainsProductQueryRequest getDetailsByBrandContainsProductQueryRequest)
        {
            var response = await base._mediator.Send(getDetailsByBrandContainsProductQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
