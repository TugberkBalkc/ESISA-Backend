using AutoMapper;
using BuildingBlocks.Constants;
using BuildingBlocks.Events.Comment;
using BuildingBlocks.QueueFactory;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateWholesaleAdvertComment
{
    public class CreateCorporateCustomerWholesaleAdvertCommentCommandHandler : IRequestHandler<CreateCorporateCustomerWholesaleAdvertCommentCommandRequest, CreateCorporateCustomerWholesaleAdvertCommentCommandResponse>
    {
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly ICorporateCustomerWholesaleAdvertCommentQueryRepository _corporateCustomerWholesaleAdvertCommentQueryRepository;

        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;

        private readonly IMapper _mapper;

        public CreateCorporateCustomerWholesaleAdvertCommentCommandHandler(ICorporateCustomerQueryRepository corporateCustomerQueryRepository, IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, ICorporateCustomerWholesaleAdvertCommentQueryRepository corporateCustomerWholesaleAdvertCommentQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _corporateCustomerWholesaleAdvertCommentQueryRepository = corporateCustomerWholesaleAdvertCommentQueryRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateCorporateCustomerWholesaleAdvertCommentCommandResponse> Handle(CreateCorporateCustomerWholesaleAdvertCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetByIdAsync(request.CorporateCustomerId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var wholesaleAdvert = await _wholesaleAdvertQueryRepository.GetByIdAsync(request.WholesaleAdvertId);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdvert);

            var wholesaleAdvertComment = await _corporateCustomerWholesaleAdvertCommentQueryRepository.GetSingleAsync(e => e.CorporateCustomerId == request.CorporateCustomerId && e.WholesaleAdvertId == request.WholesaleAdvertId && e.Content == request.CommentContent && e.Title == request.CommentTitle);

            await _evaluationBusinessRules.ExistsCheck(wholesaleAdvertComment, ResponseMessages.Comment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.CorporateCustomerWholesaleAdvertCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertCommentQueueName,
                                                  obj: new CreateCorporateCustomerWholesaleAdvertCommentEvent()
                                                  {
                                                      CorporateCustomerId = request.CorporateCustomerId,
                                                      WholesaleAdvertId = request.WholesaleAdvertId,
                                                      Title = request.CommentTitle,
                                                      Content = request.CommentContent
                                                  });

            var corporateCustomerWholesaleAdvertCommentDto = _mapper.Map<CorporateCustomerWholesaleAdvertCommentDto>(request);

            return await Task.FromResult(new CreateCorporateCustomerWholesaleAdvertCommentCommandResponse(new SuccessfulContentResponse<CorporateCustomerWholesaleAdvertCommentDto>(corporateCustomerWholesaleAdvertCommentDto,
                                                                                 ResponseTitles.Success,
                                                                                 ResponseMessages.CommentCreated,
                                                                                 HttpStatusCode.Created)));
        }
    }
}
