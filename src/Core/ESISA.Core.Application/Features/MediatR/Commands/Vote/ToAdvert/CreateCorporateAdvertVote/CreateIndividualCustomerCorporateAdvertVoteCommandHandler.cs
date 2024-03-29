﻿using AutoMapper;
using BuildingBlocks.Constants;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertVote
{
    public class CreateIndividualCustomerCorporateAdvertVoteCommandHandler : IRequestHandler<CreateIndividualCustomerCorporateAdvertVoteCommandRequest, CreateIndividualCustomerCorporateAdvertVoteCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly IIndividualCustomerCorporateAdvertVoteQueryRepository _individualCustomerCorporateAdvertVoteQueryRepository;

        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        private readonly IMapper _mapper;

        public CreateIndividualCustomerCorporateAdvertVoteCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, IIndividualCustomerCorporateAdvertVoteQueryRepository individualCustomerCorporateAdvertVoteQueryRepository,  IndividualStarterBusinessRules individualStarterBusinessRules, CorporateAdvertBusinessRules corporateAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _individualCustomerCorporateAdvertVoteQueryRepository = individualCustomerCorporateAdvertVoteQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateIndividualCustomerCorporateAdvertVoteCommandResponse> Handle(CreateIndividualCustomerCorporateAdvertVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var corporateAdvert = await _corporateAdvertQueryRepository.GetByIdAsync(request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);

            var corporateAdvertVote = await _individualCustomerCorporateAdvertVoteQueryRepository.GetSingleAsync(e=>e.IndividualCustomerId == request.IndividualCustomerId && e.CorporateAdvertId == request.CorporateAdvertId);

            await _evaluationBusinessRules.ExistsCheck(corporateAdvertVote, ResponseMessages.Vote);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerCorporateAdvertVoteExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.CreateIndividualCustomerCorporateAdvertVoteQueueName,
                                                  obj: new CreateIndividualCustomerCorporateAdvertVoteEvent()
                                                  {
                                                      CorporateAdvertId = request.CorporateAdvertId,
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      VoteType = Convert.ToInt16(request.VoteType)
                                                  });

            var individualCustomerCorporateAdvertDto = _mapper.Map<IndividualCustomerCorporateAdvertVoteDto>(request);

            return await Task.FromResult(new CreateIndividualCustomerCorporateAdvertVoteCommandResponse(new SuccessfulContentResponse<IndividualCustomerCorporateAdvertVoteDto>(individualCustomerCorporateAdvertDto,
                                                                                  ResponseTitles.Success,
                                                                                  ResponseMessages.AdvertVoted,
                                                                                  HttpStatusCode.Created)));
        }
    }
}
