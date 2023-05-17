using BuildingBlocks.Constants;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.DeleteIndividualDealerVote
{
    public class DeleteIndividualCustomerIndividualDealerVoteCommandHandler : IRequestHandler<DeleteIndividualCustomerIndividualDealerVoteCommandRequest, DeleteIndividualCustomerIndividualDealerVoteCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly IIndividualDealerQueryRepository _individualDealerQueryRepository;
        private readonly IIndividualCustomerIndividualDealerVoteQueryRepository _individualCustomerIndividualDealerVoteQueryRepository;
        
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public DeleteIndividualCustomerIndividualDealerVoteCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, IIndividualDealerQueryRepository individualDealerQueryRepository, IIndividualCustomerIndividualDealerVoteQueryRepository individualCustomerIndividualDealerVoteQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _individualDealerQueryRepository = individualDealerQueryRepository;
            _individualCustomerIndividualDealerVoteQueryRepository = individualCustomerIndividualDealerVoteQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteIndividualCustomerIndividualDealerVoteCommandResponse> Handle(DeleteIndividualCustomerIndividualDealerVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var individualDealer = await _individualDealerQueryRepository.GetByIdAsync(request.IndividualDealerId);

            await _individualStarterBusinessRules.NullCheck(individualDealer);

            var individualDealerVote = await _individualCustomerIndividualDealerVoteQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.IndividualDealerId == request.IndividualDealerId);

            await _evaluationBusinessRules.NullCheck(individualDealerVote, ResponseMessages.Vote);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerIndividualDealerVoteExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteIndividualCustomerIndividualDealerVoteQueueName,
                                                  obj: new DeleteIndividualCustomerIndividualDealerVoteEvent()
                                                  {
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      IndividualDealerId = request.IndividualDealerId
                                                  });

            return await Task.FromResult(new DeleteIndividualCustomerIndividualDealerVoteCommandResponse(new SuccessfulContentResponse<Guid>(request.IndividualDealerId,
               ResponseTitles.Success,
               ResponseMessages.VoteDeleted,
               HttpStatusCode.OK)));
        }
    }
}
