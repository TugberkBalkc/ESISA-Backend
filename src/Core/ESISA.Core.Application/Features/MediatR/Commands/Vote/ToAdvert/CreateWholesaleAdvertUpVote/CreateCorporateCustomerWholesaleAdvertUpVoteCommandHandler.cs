﻿using AutoMapper;
using BuildingBlocks.Constants;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Enums;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateWholesaleAdvertUpVote
{
    public class CreateCorporateCustomerWholesaleAdvertUpVoteCommandHandler : IRequestHandler<CreateCorporateCustomerWholesaleAdvertUpVoteCommandRequest, CreateCorporateCustomerWholesaleAdvertUpVoteCommandResponse>
    {
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly ICorporateCustomerWholesaleAdvertVoteQueryRepository _corporateCustomerWholesaleAdvertVoteQueryRepository;

        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        private readonly IMapper _mapper;

        public CreateCorporateCustomerWholesaleAdvertUpVoteCommandHandler(ICorporateCustomerQueryRepository corporateCustomerQueryRepository, IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, ICorporateCustomerWholesaleAdvertVoteQueryRepository corporateCustomerWholesaleAdvertVoteQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _corporateCustomerWholesaleAdvertVoteQueryRepository = corporateCustomerWholesaleAdvertVoteQueryRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateCorporateCustomerWholesaleAdvertUpVoteCommandResponse> Handle(CreateCorporateCustomerWholesaleAdvertUpVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetByIdAsync(request.CorporateCustomerId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var wholesaleAdvert = await _wholesaleAdvertQueryRepository.GetByIdAsync(request.WholesaleAdvertId);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdvert);

            var wholesaleAdvertVote = await _corporateCustomerWholesaleAdvertVoteQueryRepository.GetSingleAsync(e => e.CorporateCustomerId == request.CorporateCustomerId && e.WholesaleAdvertId == request.WholesaleAdvertId);

            await _evaluationBusinessRules.ExistsCheck(wholesaleAdvertVote, ResponseMessages.Vote);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertVoteQueueName,
                                                  obj: new CreateCorporateCustomerWholesaleAdvertVoteEvent()
                                                  {
                                                      CorporateCustomerId = request.CorporateCustomerId,
                                                      WholesaleAdvertId = request.WholesaleAdvertId,
                                                      VoteType = Convert.ToInt16(VoteType.UpVote)
                                                  });

            var corporateCustomerWholesaleAdvertVoteDto = _mapper.Map<CorporateCustomerWholesaleAdvertVoteDto>(request);

            return await Task.FromResult(new CreateCorporateCustomerWholesaleAdvertUpVoteCommandResponse(new SuccessfulContentResponse<CorporateCustomerWholesaleAdvertVoteDto>(corporateCustomerWholesaleAdvertVoteDto,
                                                                                 ResponseTitles.Success,
                                                                                 ResponseMessages.AdvertUpVoted,
                                                                                 HttpStatusCode.Created)));
        }
    }

}
