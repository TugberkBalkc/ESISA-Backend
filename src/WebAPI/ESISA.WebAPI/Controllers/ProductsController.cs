using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Update;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetAllProductDetails;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetAllProducts;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByBrandId;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByCategoryId;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByDynamic;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsById;
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
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] GetAllProductsQueryRequest getAllProductsQueryRequest) 
        {
            var response = await base._mediator.Send(getAllProductsQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllProductDetails")]
        public async Task<IActionResult> GetAllProductDetailsAsync([FromQuery] GetAllProductDetailsQueryRequest getAllProductDetailsQueryRequest)
        {
            var response = await base._mediator.Send(getAllProductDetailsQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("GetProductDetailsByDynamic")]
        public async Task<IActionResult> GetProductDetailsByDynamicAsync([FromBody] GetProductDetailsByDynamicQueryRequest getProductDetailsByDynamicQueryRequest)
        {
            var response = await base._mediator.Send(getProductDetailsByDynamicQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetProductDetailsByCategoryId")]
        public async Task<IActionResult> GetProductDetailsByCategoryIdAsync([FromQuery] GetProductDetailsByCategoryIdQueryRequest getProductDetailsByCategoryIdQueryRequest)
        {
            var response = await base._mediator.Send(getProductDetailsByCategoryIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetProductDetailsByBrandId")]
        public async Task<IActionResult> GetProductDetailsByBrandIdAsync([FromQuery] GetProductDetailsByBrandIdQueryRequest getProductDetailsByBrandIdQueryRequest)
        {
            var response = await base._mediator.Send(getProductDetailsByBrandIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetProductDetailsById")]
        public async Task<IActionResult> GetProductDetailsByIdAsync([FromQuery] GetProductDetailsByIdQueryRequest getProductDetailsByIdQueryRequest)
        {
            var response = await base._mediator.Send(getProductDetailsByIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
