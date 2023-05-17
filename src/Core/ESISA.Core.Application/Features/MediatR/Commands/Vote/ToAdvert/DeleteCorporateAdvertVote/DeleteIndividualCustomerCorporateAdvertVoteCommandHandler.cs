using AutoMapper;
using BuildingBlocks.Constants;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteCorporateAdvertVote
{
    public class DeleteIndividualCustomerCorporateAdvertVoteCommandHandler : IRequestHandler<DeleteIndividualCustomerCorporateAdvertVoteCommandRequest, DeleteIndividualCustomerCorporateAdvertVoteCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly IIndividualCustomerCorporateAdvertVoteQueryRepository _individualCustomerCorporateAdvertVoteQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public DeleteIndividualCustomerCorporateAdvertVoteCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository,IIndividualCustomerCorporateAdvertVoteQueryRepository individualCustomerCorporateAdvertVoteQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, CorporateAdvertBusinessRules corporateAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _individualCustomerCorporateAdvertVoteQueryRepository = individualCustomerCorporateAdvertVoteQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteIndividualCustomerCorporateAdvertVoteCommandResponse> Handle(DeleteIndividualCustomerCorporateAdvertVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var corporateAdvert = await _corporateAdvertQueryRepository.GetByIdAsync(request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);

            var corporateAdvertVote = await _individualCustomerCorporateAdvertVoteQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.CorporateAdvertId == request.CorporateAdvertId);

            await _evaluationBusinessRules.NullCheck(corporateAdvertVote, ResponseMessages.Vote);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerCorporateAdvertVoteExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertVoteQueueName,
                                                  obj: new DeleteIndividualCustomerCorporateAdvertVoteEvent()
                                                  {
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      CorporateAdvertId = request.CorporateAdvertId
                                                  });

            return await Task.FromResult(new DeleteIndividualCustomerCorporateAdvertVoteCommandResponse(new SuccessfulContentResponse<Guid>(request.CorporateAdvertId,
               ResponseTitles.Success,
               ResponseMessages.VoteDeleted,
               HttpStatusCode.OK)));
        }
    }

}
