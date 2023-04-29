
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.MarkAsOutOfStock;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UndoOutOfStock;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Update;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateAdvertsController : CustomControllerBase
    {
        public CorporateAdvertsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateCorporateAdvert")]
        public async Task<IActionResult> CreateCorporateAdvert([FromBody] CreateCorporateAdvertCommandRequest createCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(createCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("MarkAsOutOfStock")]
        public async Task<IActionResult> MarkAsOutOfStock([FromBody] MarkCorporateAdvertAsOutOfStockCommandRequest  markCorporateAdvertAsOutOfStockCommandRequest)
        {
            var response = await _mediator.Send(markCorporateAdvertAsOutOfStockCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UndoOutOfStock")]
        public async Task<IActionResult> UndoOutOfStock([FromBody] UndoCorporateAdvertOutOfStockCommandRequest  undoCorporateAdvertOutOfStockCommandRequest)
        {
            var response = await _mediator.Send(undoCorporateAdvertOutOfStockCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeleteCorporateAdvert")]
        public async Task<IActionResult> DeleteCorporateAdvert([FromBody] DeleteCorporateAdvertCommandRequest deleteCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(deleteCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("UpdateCorporateAdvert")]
        public async Task<IActionResult> UpdateCorporateAdvert([FromBody] UpdateCorporateAdvertCommandRequest updateCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(updateCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
