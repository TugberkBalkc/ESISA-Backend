using BuildingBlocks.Constants;
using BuildingBlocks.Events.Comment;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteCorporateAdvertComment
{
    public class DeleteIndividualCustomerCorporateAdvertCommentCommandHandler : IRequestHandler<DeleteIndividualCustomerCorporateAdvertCommentCommandRequest, DeleteIndividualCustomerCorporateAdvertCommentCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly IIndividualCustomerCorporateAdvertCommentQueryRepository _individualCustomerCorporateAdvertCommentQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        public DeleteIndividualCustomerCorporateAdvertCommentCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, IIndividualCustomerCorporateAdvertCommentQueryRepository individualCustomerCorporateAdvertCommentQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, CorporateAdvertBusinessRules corporateAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _individualCustomerCorporateAdvertCommentQueryRepository = individualCustomerCorporateAdvertCommentQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
        }

        public async Task<DeleteIndividualCustomerCorporateAdvertCommentCommandResponse> Handle(DeleteIndividualCustomerCorporateAdvertCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var corporateAdvert = await _corporateAdvertQueryRepository.GetByIdAsync(request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);

            var corporateAdvertComment = await _individualCustomerCorporateAdvertCommentQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.CorporateAdvertId == request.CorporateAdvertId && e.Content == request.CommentContent && e.Title == request.CommentTitle);

            await _evaluationBusinessRules.NullCheck(corporateAdvertComment, ResponseMessages.Comment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerCorporateAdvertCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertCommentQueueName,
                                                  obj: new DeleteIndividualCustomerCorporateAdvertCommentEvent()
                                                  {
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      CorporateAdvertId = request.CorporateAdvertId
                                                  });

            return await Task.FromResult(new DeleteIndividualCustomerCorporateAdvertCommentCommandResponse(new SuccessfulContentResponse<Guid>(request.CorporateAdvertId,
               ResponseTitles.Success,
               ResponseMessages.CommentDeleted,
               HttpStatusCode.OK)));
        }
    }
}
