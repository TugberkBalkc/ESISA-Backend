using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.ReducePriceByRate;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdvertDetails;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByBrandId;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByCategoryId;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByDealerId;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByDynamic;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByProductId;
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
        public async Task<IActionResult> CretaeIndividualAdvertAsync([FromBody] CreateIndividualAdvertCommandRequest createIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(createIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("AddPhotoToIndividualAdvert")]
        public async Task<IActionResult> AddPhotoToIndividualAdvertAsync([FromBody] AddPhotoToIndividualAdvertCommandRequest addPhotoToIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(addPhotoToIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeletePhotoInIndividualAdvert")]
        public async Task<IActionResult> DeletePhotoInIndividualAdvertAsync([FromBody] DeletePhotoInIndividualAdvertCommandRequest deletePhotoInIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(deletePhotoInIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeleteIndividualAdvert")]
        public async Task<IActionResult> DeleteIndividualAdvertAsync([FromBody] DeleteIndividualAdvertCommandRequest deleteIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(deleteIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("UpdateIndividualAdvert")]
        public async Task<IActionResult> UpdateIndividualAdvertAsync([FromBody] UpdateIndividualAdvertCommandRequest updateIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(updateIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateIndividualAdvertPrice")]
        public async Task<IActionResult> UpdateIndividualAdvertPriceAsync([FromBody] UpdateIndividualAdvertPriceCommandRequest individualAdvertPriceCommandRequest)
        {
            var response = await _mediator.Send(individualAdvertPriceCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("RaiseIndividualAdvertPriceByRate")]
        public async Task<IActionResult> RaiseIndividualAdvertPriceByRateAsync([FromBody] RaiseIndividualAdvertPriceByRateCommandRequest raiseIndividualAdvertPriceByRateCommandRequest)
        {
            var response = await _mediator.Send(raiseIndividualAdvertPriceByRateCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("ReduceIndividualAdvertPriceByRate")]
        public async Task<IActionResult> ReduceIndividualAdvertPriceByRateAsync([FromBody] ReduceIndividualAdvertPriceByRateCommandRequest reduceIndividualAdvertPriceByRateCommandRequest)
        {
            var response = await _mediator.Send(reduceIndividualAdvertPriceByRateCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("MarkAsSold")]
        public async Task<IActionResult> MarkAsSoldAsync([FromBody] MarkIndividualAdvertAsSoldCommandRequest markIndividualAdvertAsSoldCommandRequest)
        {
            var response = await _mediator.Send(markIndividualAdvertAsSoldCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("GetIndividualAdvertDetailsByDynamic")]
        public async Task<IActionResult> GetIndividualAdvertDetailsByDynamic([FromBody] GetIndividualAdvertDetailsByDynamicQueryRequest getIndividualAdvertDetailsByDynamicQueryRequest)
        {
            var response = await _mediator.Send(getIndividualAdvertDetailsByDynamicQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllIndividualAdverts")]
        public async Task<IActionResult> GetAllIndividualAdvertsAsync([FromQuery] GetAllIndividualAdvertsQueryRequest getAllIndividualAdvertsQueryRequest)
        {
            var response = await _mediator.Send(getAllIndividualAdvertsQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }


        [HttpGet("GetAllIndividualAdvertDetails")]
        public async Task<IActionResult> GetAllIndividualAdvertDetailsAsync([FromQuery] GetAllIndividualAdvertDetailsQueryRequest getAllIndividualAdvertDetailsQueryRequest)
        {
            var response = await _mediator.Send(getAllIndividualAdvertDetailsQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetIndividualAdvertDetailsByCategoryId")]
        public async Task<IActionResult> GetIndividualAdvertDetailsByCategoryId([FromQuery] GetIndividualAdvertDetailsByCategoryIdQueryRequest getIndividualAdvertDetailsByCategoryIdQueryRequest)
        {
            var response = await _mediator.Send(getIndividualAdvertDetailsByCategoryIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetIndividualAdvertDetailsByBrandId")]
        public async Task<IActionResult> GetIndividualAdvertDetailsByBrandId([FromQuery] GetIndividualAdvertDetailsByBrandIdQueryRequest getIndividualAdvertDetailsByBrandIdQueryRequest)
        {
            var response = await _mediator.Send(getIndividualAdvertDetailsByBrandIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetIndividualAdvertDetailsByDealerId")]
        public async Task<IActionResult> GetIndividualAdvertDetailsByDealerId([FromQuery] GetIndividualAdvertDetailsByDealerIdQueryRequest getIndividualAdvertDetailsByDealerIdQueryRequest)
        {
            var response = await _mediator.Send(getIndividualAdvertDetailsByDealerIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetIndividualAdvertDetailsByProductId")]
        public async Task<IActionResult> GetIndividualAdvertDetailsByProductId([FromQuery] GetIndividualAdvertDetailsByProductIdQueryRequest getIndividualAdvertDetailsByProductIdQueryRequest)
        {
            var response = await _mediator.Send(getIndividualAdvertDetailsByProductIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
