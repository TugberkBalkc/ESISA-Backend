using ESISA.Core.Application.Features.MediatR.Commands.Products.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Update;
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
    }
}
