using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.ReducePriceByRate;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdverts;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualAdvertsController : CustomControllerBase
    {
        public IndividualAdvertsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateIndividualAdvert")]
        public async Task<IActionResult> CretaeIndividualAdvert([FromBody] CreateIndividualAdvertCommandRequest createIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(createIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("AddPhotoToIndividualAdvert")]
        public async Task<IActionResult> AddPhotoToIndividualAdvert([FromBody] AddPhotoToIndividualAdvertCommandRequest addPhotoToIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(addPhotoToIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeletePhotoInIndividualAdvert")]
        public async Task<IActionResult> DeletePhotoInIndividualAdvert([FromBody] DeletePhotoInIndividualAdvertCommandRequest deletePhotoInIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(deletePhotoInIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeleteIndividualAdvert")]
        public async Task<IActionResult> DeleteIndividualAdvert([FromBody] DeleteIndividualAdvertCommandRequest deleteIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(deleteIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("UpdateIndividualAdvert")]
        public async Task<IActionResult> UpdateIndividualAdvert([FromBody] UpdateIndividualAdvertCommandRequest updateIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(updateIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateIndividualAdvertPrice")]
        public async Task<IActionResult> UpdateIndividualAdvertPrice([FromBody] UpdateIndividualAdvertPriceCommandRequest individualAdvertPriceCommandRequest)
        {
            var response = await _mediator.Send(individualAdvertPriceCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("RaiseIndividualAdvertPriceByRate")]
        public async Task<IActionResult> RaiseIndividualAdvertPriceByRate([FromBody] RaiseIndividualAdvertPriceByRateCommandRequest raiseIndividualAdvertPriceByRateCommandRequest)
        {
            var response = await _mediator.Send(raiseIndividualAdvertPriceByRateCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("ReduceIndividualAdvertPriceByRate")]
        public async Task<IActionResult> ReduceIndividualAdvertPriceByRate([FromBody] ReduceIndividualAdvertPriceByRateCommandRequest reduceIndividualAdvertPriceByRateCommandRequest)
        {
            var response = await _mediator.Send(reduceIndividualAdvertPriceByRateCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("MarkAsSold")]
        public async Task<IActionResult> MarkAsSold([FromBody] MarkIndividualAdvertAsSoldCommandRequest markIndividualAdvertAsSoldCommandRequest)
        {
            var response = await _mediator.Send(markIndividualAdvertAsSoldCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllIndividualAdverts")]
        public async Task<IActionResult> GetAllIndividualAdverts([FromQuery] GetAllIndividualAdvertsQueryRequest getAllIndividualAdvertsQueryRequest)
        {
            var response = await _mediator.Send(getAllIndividualAdvertsQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
