﻿
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.MarkAsOutOfStock;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UndoOutOfStock;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Update;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.AddPhoto;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.DeletePhoto;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.RaisePriceByRate;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdatePrice;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdateStock;
using ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetAllCorporateAdvertDetails;
using ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByCategoryId;
using ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByBrandId;
using ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByProductId;
using ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByDealerId;

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
        public async Task<IActionResult> CreateCorporateAdvertAsync([FromBody] CreateCorporateAdvertCommandRequest createCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(createCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("AddPhotoToCorporateAdvert")]
        public async Task<IActionResult> AddPhotoToCorporateAdvertAsync([FromBody] AddPhotoToCorporateAdvertCommandRequest addPhotoToCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(addPhotoToCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeletePhotoInCorporateAdvert")]
        public async Task<IActionResult> DeletePhotoInCorporateAdvertAsync([FromBody] DeletePhotoInCorporateAdvertCommandRequest deletePhotoInCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(deletePhotoInCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("MarkAsOutOfStock")]
        public async Task<IActionResult> MarkAsOutOfStockAsync([FromBody] MarkCorporateAdvertAsOutOfStockCommandRequest  markCorporateAdvertAsOutOfStockCommandRequest)
        {
            var response = await _mediator.Send(markCorporateAdvertAsOutOfStockCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UndoOutOfStock")]
        public async Task<IActionResult> UndoOutOfStockAsync([FromBody] UndoCorporateAdvertOutOfStockCommandRequest  undoCorporateAdvertOutOfStockCommandRequest)
        {
            var response = await _mediator.Send(undoCorporateAdvertOutOfStockCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("DeleteCorporateAdvert")]
        public async Task<IActionResult> DeleteCorporateAdvertAsync([FromBody] DeleteCorporateAdvertCommandRequest deleteCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(deleteCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("UpdateCorporateAdvert")]
        public async Task<IActionResult> UpdateCorporateAdvertAsync([FromBody] UpdateCorporateAdvertCommandRequest updateCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(updateCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("RaiseCorporateAdvertPriceByRate")]
        public async Task<IActionResult> RaiseCorporateAdvertPriceByRateAsync([FromBody] RaiseCorporateAdvertPriceByRateCommandRequest raiseCorporateAdvertPriceByRateCommandRequest)
        {
            var response = await _mediator.Send(raiseCorporateAdvertPriceByRateCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateCorporateAdvertPrice")]
        public async Task<IActionResult> UpdateCorporateAdvertPriceAsync([FromBody] UpdateCorporateAdvertPriceCommandRequest updateCorporateAdvertPriceCommandRequest)
        {
            var response = await _mediator.Send(updateCorporateAdvertPriceCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateCorporateAdvertStock")]
        public async Task<IActionResult> UpdateCorporateAdvertStockAsync([FromBody] UpdateCorporateAdvertStockCommandRequest updateCorporateAdvertStockCommandRequest)
        {
            var response = await _mediator.Send(updateCorporateAdvertStockCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllCorporateAdverts")]
        public async Task<IActionResult> GetAllCorporateAdvertsAsync([FromQuery] GetAllCorporateAdvertDetailsQueryRequest getAllCorporateAdvertDetailsQueryRequest)
        {
            var response = await _mediator.Send(getAllCorporateAdvertDetailsQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetAllCorporateAdvertDetails")]
        public async Task<IActionResult> GetAllCorporateAdvertDetailsAsync([FromQuery] GetAllCorporateAdvertDetailsQueryRequest getAllCorporateAdvertDetailsQueryRequest)
        {
            var response = await _mediator.Send(getAllCorporateAdvertDetailsQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetCorporateAdvertDetailsByCategoryId")]
        public async Task<IActionResult> GetCorporateAdvertDetailsByCategoryIdAsync([FromQuery] GetCorporateAdvertDetailsByCategoryIdQueryRequest getCorporateAdvertDetailsByCategoryIdQueryRequest)
        {
            var response = await _mediator.Send(getCorporateAdvertDetailsByCategoryIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetCorporateAdvertDetailsByBrandId")]
        public async Task<IActionResult> GetCorporateAdvertDetailsByBrandIdAsync([FromQuery] GetCorporateAdvertDetailsByBrandIdQueryRequest getCorporateAdvertDetailsByBrandIdQueryRequest)
        {
            var response = await _mediator.Send(getCorporateAdvertDetailsByBrandIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetCorporateAdvertDetailsByDealerId")]
        public async Task<IActionResult> GetCorporateAdvertDetailsByDealerIdAsync([FromQuery] GetCorporateAdvertDetailsByDealerIdQueryRequest getCorporateAdvertDetailsByDealerIdQueryRequest)
        {
            var response = await _mediator.Send(getCorporateAdvertDetailsByDealerIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpGet("GetCorporateAdvertDetailsByProductId")]
        public async Task<IActionResult> GetCorporateAdvertDetailsByProductIdAsync([FromQuery] GetCorporateAdvertDetailsByProductIdQueryRequest getCorporateAdvertDetailsByProductIdQueryRequest)
        {
            var response = await _mediator.Send(getCorporateAdvertDetailsByProductIdQueryRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
