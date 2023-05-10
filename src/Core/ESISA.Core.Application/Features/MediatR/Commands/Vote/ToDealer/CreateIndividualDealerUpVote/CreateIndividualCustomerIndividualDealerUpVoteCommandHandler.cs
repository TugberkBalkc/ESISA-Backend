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

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerUpVote
{
    public class CreateIndividualCustomerIndividualDealerUpVoteCommandHandler : IRequestHandler<CreateIndividualCustomerIndividualDealerUpVoteCommandRequest, CreateIndividualCustomerIndividualDealerUpVoteCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly IIndividualDealerQueryRepository _individualDealerQueryRepository;
        private readonly IIndividualCustomerIndividualDealerVoteQueryRepository _individualCustomerIndividualDealerVoteQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;
        private readonly IMapper _mapper;

        public CreateIndividualCustomerIndividualDealerUpVoteCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, IIndividualDealerQueryRepository individualDealerQueryRepository, IIndividualCustomerIndividualDealerVoteQueryRepository ındividualCustomerIndividualDealerVoteQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _individualDealerQueryRepository = individualDealerQueryRepository;
            _individualCustomerIndividualDealerVoteQueryRepository = ındividualCustomerIndividualDealerVoteQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateIndividualCustomerIndividualDealerUpVoteCommandResponse> Handle(CreateIndividualCustomerIndividualDealerUpVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var individualDealer = await _individualDealerQueryRepository.GetByIdAsync(request.IndividualDealerId);

            await _individualStarterBusinessRules.NullCheck(individualDealer);

            var individualCustomerIndividualDealerVote = await _individualCustomerIndividualDealerVoteQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.IndividualDealerId == request.IndividualDealerId);

            await _evaluationBusinessRules.ExistsCheck(individualCustomerIndividualDealerVote);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerIndividualDealerVoteExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.CreateIndividualCustomerIndividualDealerVoteQueueName,
                                                  obj: new CreateIndividualCustomerIndividualDealerVoteEvent()
                                                  {
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      IndividualDealerId = request.IndividualDealerId,
                                                      VoteType = Convert.ToInt16(VoteType.UpVote)
                                                  });

            var individualCustomerIndividualDealerVoteDto = _mapper.Map<IndividualCustomerIndividualDealerVoteDto>(request);

            return await Task.FromResult(new CreateIndividualCustomerIndividualDealerUpVoteCommandResponse(new SuccessfulContentResponse<IndividualCustomerIndividualDealerVoteDto>(individualCustomerIndividualDealerVoteDto,
                                                                                   ResponseTitles.Success,
                                                                                   ResponseMessages.DealerUpVoted,
                                                                                   HttpStatusCode.Created)));
        }
    }
}