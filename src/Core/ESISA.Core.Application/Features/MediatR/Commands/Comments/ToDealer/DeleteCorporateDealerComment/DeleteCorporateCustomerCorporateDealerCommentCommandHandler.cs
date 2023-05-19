using BuildingBlocks.Constants;
using BuildingBlocks.Events.Comment;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteCorporateDealerComment
{
    public class DeleteCorporateCustomerCorporateDealerCommentCommandHandler : IRequestHandler<DeleteCorporateCustomerCorporateDealerCommentCommandRequest, DeleteCorporateCustomerCorporateDealerCommentCommandResponse>
    {
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly ICorporateCustomerCorporateDealerCommentQueryRepository _corporateCustomerCorporateDealerCommentQueryRepository;
        private readonly ICorporateDealerQueryRepository _corporateDealerQueryRepository;
        private readonly CorporateDealerBusinessRules _corporateDealerBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public DeleteCorporateCustomerCorporateDealerCommentCommandHandler(ICorporateCustomerQueryRepository corporateCustomerQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, ICorporateCustomerCorporateDealerCommentQueryRepository corporateCustomerCorporateDealerCommentQueryRepository, ICorporateDealerQueryRepository corporateDealerQueryRepository, CorporateDealerBusinessRules corporateDealerBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _corporateCustomerCorporateDealerCommentQueryRepository = corporateCustomerCorporateDealerCommentQueryRepository;
            _corporateDealerQueryRepository = corporateDealerQueryRepository;
            _corporateDealerBusinessRules = corporateDealerBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteCorporateCustomerCorporateDealerCommentCommandResponse> Handle(DeleteCorporateCustomerCorporateDealerCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetByIdAsync(request.CorporateCustomerId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var corporateDealer = await _corporateDealerQueryRepository.GetByIdAsync(request.CorporateDealerId);

            await _corporateDealerBusinessRules.NullCheck(corporateDealer);
            await _corporateDealerBusinessRules.CheckIfCorporateDealerAccountActiveOnCommenting(corporateDealer);

            var corporateDealerComment = await _corporateCustomerCorporateDealerCommentQueryRepository.GetSingleAsync(e => e.CorporateCustomerId == request.CorporateCustomerId && e.CorporateDealerId == request.CorporateDealerId && e.Title == request.CommentTitle && e.Content == request.CommentContent);

            await _evaluationBusinessRules.NullCheck(corporateDealerComment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.CorporateCustomerCorporateDealerCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteCorporateCustomerCorporateDealerCommentQueueName,
                                                  obj: new DeleteCorporateCustomerCorporateDealerCommentEvent()
                                                  {
                                                      CorporateCustomerId = request.CorporateCustomerId,
                                                      CorporateDealerId = request.CorporateDealerId,
                                                      Title = request.CommentTitle,
                                                      Content = request.CommentContent
                                                  });

            return await Task.FromResult(new DeleteCorporateCustomerCorporateDealerCommentCommandResponse(new SuccessfulContentResponse<Guid>(request.CorporateDealerId,
               ResponseTitles.Success,
               ResponseMessages.CommentDeleted,
               HttpStatusCode.OK)));
        }
    }
}
