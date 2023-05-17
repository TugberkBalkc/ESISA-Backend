using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertDownVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertUpVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateWholesaleAdvertDownVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateWholesaleAdvertUpVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateWholesaleAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteCorporateAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteWholesaleAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerUpVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.DeleteIndividualDealerVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerDownVote;
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

        [HttpPost("CreateCorporateCustomerWholesaleAdvertUpVote")]
        public async Task<IActionResult> CreateCorporateCustomerWholesaleAdvertUpVoteAsync(CreateCorporateCustomerWholesaleAdvertUpVoteCommandRequest createCorporateCustomerWholesaleAdvertUpVoteCommandRequest)
        {
            var response = await _mediator.Send(createCorporateCustomerWholesaleAdvertUpVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateCorporateCustomerWholesaleAdvertDownVote")]
        public async Task<IActionResult> CreateCorporateCustomerWholesaleAdvertDownVoteAsync(CreateCorporateCustomerWholesaleAdveretDownVoteCommandRequest createCorporateCustomerWholesaleAdvertDownVoteCommandRequest)
        {
            var response = await _mediator.Send(createCorporateCustomerWholesaleAdvertDownVoteCommandRequest);

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

        [HttpPost("CreateIndividualCustomerCorporateAdvertUpVote")]
        public async Task<IActionResult> CreateIndividualCustomerCorporateAdvertUpVoteAsync(CreateIndividualCustomerCorporateAdvertUpVoteCommandRequest createIndividualCustomerCorporateAdvertUpVoteCommandRequest)
        {
            var response = await _mediator.Send(createIndividualCustomerCorporateAdvertUpVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateIndividualCustomerCorporateAdvertDownVote")]
        public async Task<IActionResult> CreateIndividualCustomerCorporateAdvertDownVoteAsync(CreateIndividualCustomerCorporateAdvertDownVoteCommandRequest createIndividualCustomerCorporateAdvertDownVoteCommandRequest)
        {
            var response = await _mediator.Send(createIndividualCustomerCorporateAdvertDownVoteCommandRequest);

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

        [HttpPost("CreateIndividualCustomerIndividualDealerUpVote")]
        public async Task<IActionResult> CreateIndividualCustomerIndividualDealerUpVoteAsync(CreateIndividualCustomerIndividualDealerUpVoteCommandRequest createIndividualCustomerIndividualDealerUpVoteCommandRequest)
        {
            var response = await _mediator.Send(createIndividualCustomerIndividualDealerUpVoteCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateIndividualCustomerIndividualDealerDownVote")]
        public async Task<IActionResult> CreateIndividualCustomerIndividualDealerDownVoteAsync(CreateIndividualCustomerIndividualDealerDownVoteCommandRequest createIndividualCustomerIndividualDealerDownVoteCommandRequest)
        {
            var response = await _mediator.Send(createIndividualCustomerIndividualDealerDownVoteCommandRequest);

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
