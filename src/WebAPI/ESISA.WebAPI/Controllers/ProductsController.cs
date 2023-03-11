using ESISA.Core.Application.Features.MediatR.Commands.Products.Add;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Delete;
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

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] AddProductCommandRequest addProductCommandRequest)
        {
            var response = await base._mediator.Send(addProductCommandRequest);

            return response.Response.IsSucceeded == true 
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync([FromBody] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var response = await base._mediator.Send(deleteProductCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            var response = await base._mediator.Send(updateProductCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
