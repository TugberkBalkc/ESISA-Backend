using BuildingBlocks.Constants;
using BuildingBlocks.Events.Comment;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteIndivdualDealerComment
{
    public class DeleteIndividualCustomerIndividualDealerCommentCommandHandler : IRequestHandler<DeleteIndividualCustomerIndividualDealerCommentCommandRequest, DeleteIndividualCustomerIndividualDealerCommentCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly IIndividualCustomerIndividualDealerCommentQueryRepository _individualCustomerIndividualDealerCommentQueryRepository;
        private readonly IIndividualDealerQueryRepository _individualDealerQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public DeleteIndividualCustomerIndividualDealerCommentCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, IIndividualCustomerIndividualDealerCommentQueryRepository individualCustomerIndividualDealerCommentQueryRepository, IIndividualDealerQueryRepository individualDealerQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _individualCustomerIndividualDealerCommentQueryRepository = individualCustomerIndividualDealerCommentQueryRepository;
            _individualDealerQueryRepository = individualDealerQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteIndividualCustomerIndividualDealerCommentCommandResponse> Handle(DeleteIndividualCustomerIndividualDealerCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var individualDealer = await _individualDealerQueryRepository.GetByIdAsync(request.IndividualDealerId);

            await _individualStarterBusinessRules.NullCheck(individualDealer);
            await _individualStarterBusinessRules.CheckIfIndividualDealerAccountActiveOnCommenting(individualDealer);

            var individualDealerComment = await _individualCustomerIndividualDealerCommentQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.IndividualDealerId == request.IndividualDealerId && e.Title == request.CommentTitle && e.Content == request.CommentContent);

            await _evaluationBusinessRules.NullCheck(individualDealerComment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerIndividualDealerCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteIndividualCustomerIndividualDealerCommentQueueName,
                                                  obj: new DeleteIndividualCustomerIndividualDealerCommentEvent()
                                                  {
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      IndividualDealerId = request.IndividualDealerId,
                                                      Title = request.CommentTitle,
                                                      Content = request.CommentContent
                                                  });

            return await Task.FromResult(new DeleteIndividualCustomerIndividualDealerCommentCommandResponse(new SuccessfulContentResponse<Guid>(request.IndividualDealerId,
               ResponseTitles.Success,
               ResponseMessages.CommentDeleted,
               HttpStatusCode.OK)));
        }
    }
}
