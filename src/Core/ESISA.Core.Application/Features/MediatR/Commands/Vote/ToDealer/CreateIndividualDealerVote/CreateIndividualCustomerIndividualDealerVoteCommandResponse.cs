﻿using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerVote
{
    public class CreateIndividualCustomerIndividualDealerVoteCommandResponse : CommandResponseBase<IndividualCustomerIndividualDealerVoteDto>
    {
        public CreateIndividualCustomerIndividualDealerVoteCommandResponse(IContentResponse<IndividualCustomerIndividualDealerVoteDto> response) : base(response)
        {
        }
    }
}
