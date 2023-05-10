using BuildingBlocks.Constants;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.DeleteWholesaleAdvertVote
{
    public class DeleteCorporateCustomerWholesaleAdvertVoteCommandHandler : IRequestHandler<DeleteCorporateCustomerWholesaleAdvertVoteCommandRequest, DeleteCorporateCustomerWholesaleAdvertVoteCommandResponse>
    {
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly ICorporateCustomerWholesaleAdvertVoteQueryRepository _corporateCustomerWholesaleAdvertVoteQueryRepository;
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;
        public DeleteCorporateCustomerWholesaleAdvertVoteCommandHandler(ICorporateCustomerQueryRepository corporateCustomerQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, ICorporateCustomerWholesaleAdvertVoteQueryRepository corporateCustomerWholesaleAdvertVoteQueryRepository, IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _corporateCustomerWholesaleAdvertVoteQueryRepository = corporateCustomerWholesaleAdvertVoteQueryRepository;
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteCorporateCustomerWholesaleAdvertVoteCommandResponse> Handle(DeleteCorporateCustomerWholesaleAdvertVoteCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetByIdAsync(request.CorporateCustomerId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var wholesaleAdvert = await _wholesaleAdvertQueryRepository.GetByIdAsync(request.WholesaleAdvertId);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdvert);

            var wholesaleAdvertVote = await _corporateCustomerWholesaleAdvertVoteQueryRepository.GetSingleAsync(e => e.CorporateCustomerId == request.CorporateCustomerId && e.WholesaleAdvertId == request.WholesaleAdvertId);

            await _evaluationBusinessRules.NullCheck(wholesaleAdvertVote, ResponseMessages.Vote);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertVoteQueueName,
                                                  obj: new DeleteCorporateCustomerWholesaleAdvertVoteEvent()
                                                  {
                                                      CorporateCustomerId = request.CorporateCustomerId,
                                                      WholesaleAdvertId = request.WholesaleAdvertId
                                                  });

            return await Task.FromResult(new DeleteCorporateCustomerWholesaleAdvertVoteCommandResponse(new SuccessfulContentResponse<Guid>(request.WholesaleAdvertId,
               ResponseTitles.Success,
               ResponseMessages.VoteDeleted,
               HttpStatusCode.OK)));
        }
    }
}


