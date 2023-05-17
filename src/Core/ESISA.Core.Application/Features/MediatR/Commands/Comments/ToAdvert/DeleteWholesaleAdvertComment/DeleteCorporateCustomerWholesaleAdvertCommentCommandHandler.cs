using BuildingBlocks.Constants;
using BuildingBlocks.Events.Comment;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteWholesaleAdvertComment
{
    public class DeleteCorporateCustomerWholesaleAdvertCommentCommandHandler : IRequestHandler<DeleteCorporateCustomerWholesaleAdvertCommentCommandRequest, DeleteCorporateCustomerWholesaleAdvertCommentCommandResponse>
    {
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly ICorporateCustomerWholesaleAdvertCommentQueryRepository _corporateCustomerWholesaleAdvertCommentQueryRepository;
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;
        public DeleteCorporateCustomerWholesaleAdvertCommentCommandHandler(ICorporateCustomerQueryRepository corporateCustomerQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, ICorporateCustomerWholesaleAdvertCommentQueryRepository corporateCustomerWholesaleAdvertCommentQueryRepository, IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _corporateCustomerWholesaleAdvertCommentQueryRepository = corporateCustomerWholesaleAdvertCommentQueryRepository;
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteCorporateCustomerWholesaleAdvertCommentCommandResponse> Handle(DeleteCorporateCustomerWholesaleAdvertCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetByIdAsync(request.CorporateCustomerId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var wholesaleAdvert = await _wholesaleAdvertQueryRepository.GetByIdAsync(request.WholesaleAdvertId);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdvert);

            var wholesaleAdvertComment = await _corporateCustomerWholesaleAdvertCommentQueryRepository.GetSingleAsync(e => e.CorporateCustomerId == request.CorporateCustomerId && e.WholesaleAdvertId == request.WholesaleAdvertId && e.Content == request.CommentContent && e.Title == request.CommentTitle);

            await _evaluationBusinessRules.NullCheck(wholesaleAdvertComment, ResponseMessages.Comment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.CorporateCustomerWholesaleAdvertCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertCommentQueueName,
                                                  obj: new DeleteCorporateCustomerWholesaleAdvertCommentEvent()
                                                  {
                                                      CorporateCustomerId = request.CorporateCustomerId,
                                                      WholesaleAdvertId = request.WholesaleAdvertId,
                                                      Title = request.CommentTitle,
                                                      Content = request.CommentContent
                                                  });

            return await Task.FromResult(new DeleteCorporateCustomerWholesaleAdvertCommentCommandResponse(new SuccessfulContentResponse<Guid>(request.WholesaleAdvertId,
               ResponseTitles.Success,
               ResponseMessages.CommentDeleted,
               HttpStatusCode.OK)));
        }
    }

}
