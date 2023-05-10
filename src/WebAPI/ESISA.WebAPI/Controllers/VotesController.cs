using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.DeleteCorporateAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.DeleteWholesaleAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.DeleteIndividualDealerVote;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : CustomControllerBase
    {
        public VotesController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateCorporateCustomerWholesaleAdvertVote")]
        public async Task<IActionResult> CreateCorporateCustomerWholesaleAdvertVoteAsync(CreateCorporateCustomerWholesaleAdvertVoteCommandRequest createCorporateCustomerWholesaleAdvertVoteCommandRequest)
        {
            var response = await _mediator.Send(createCorporateCustomerWholesaleAdvertVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteCorporateCustomerWholesaleAdvertVote")]
        public async Task<IActionResult> DeleteCorporateCustomerWholesaleAdvertVoteAsync(DeleteCorporateCustomerWholesaleAdvertVoteCommandRequest deleteCorporateCustomerWholesaleAdvertVoteCommandRequest)
        {
            var response = await _mediator.Send(deleteCorporateCustomerWholesaleAdvertVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateIndividualCustomerCorporateAdvertVote")]
        public async Task<IActionResult> CreateIndividualCustomerCorporateAdvertVoteAsync(CreateIndividualCustomerCorporateAdvertVoteCommandRequest createIndividualCustomerCorporateAdvertVoteCommandRequest)
        {
            var response = await _mediator.Send(createIndividualCustomerCorporateAdvertVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteIndividualCustomerCorporateAdvertVote")]
        public async Task<IActionResult> DeleteIndividualCustomerCorporateAdvertVoteAsync(DeleteIndividualCustomerCorporateAdvertVoteCommandRequest deleteIndividualCustomerCorporateAdvertVoteCommandRequest)
        {
            var response = await _mediator.Send(deleteIndividualCustomerCorporateAdvertVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateIndividualCustomerIndividualDealerVote")]
        public async Task<IActionResult> CreateIndividualCustomerIndividualDealerVoteAsync(CreateIndividualCustomerIndividualDealerVoteCommandRequest createIndividualCustomerIndividualDealerVoteCommandRequest)
        {
            var response = await _mediator.Send(createIndividualCustomerIndividualDealerVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteIndividualCustomerIndividualDealerVote")]
        public async Task<IActionResult> DeleteIndividualCustomerIndividualDealerVoteAsync(DeleteIndividualCustomerIndividualDealerVoteCommandRequest deleteIndividualCustomerIndividualDealerVoteCommandRequest)
        {
            var response = await _mediator.Send(deleteIndividualCustomerIndividualDealerVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
