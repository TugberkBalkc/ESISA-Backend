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

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateCorporateDealerComment
{
    public class CreateCorporateCustomerCorporateDealerCommentCommandHandler : IRequestHandler<CreateCorporateCustomerCorporateDealerCommentCommandRequest, CreateCorporateCustomerCorporateDealerCommentCommandResponse>
    {
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly ICorporateDealerQueryRepository _corporateDealerQueryRepository;
        private readonly ICorporateCustomerCorporateDealerCommentQueryRepository _corporateCustomerCorporateDealerCommentQueryRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly CorporateDealerBusinessRules _corporateDealerBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;
        private readonly IMapper _mapper;

        public CreateCorporateCustomerCorporateDealerCommentCommandHandler(ICorporateCustomerQueryRepository corporateCustomerQueryRepository, ICorporateDealerQueryRepository corporateDealerQueryRepository, ICorporateCustomerCorporateDealerCommentQueryRepository corporateCustomerCorporateDealerCommentQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, CorporateDealerBusinessRules corporateDealerBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _corporateDealerQueryRepository = corporateDealerQueryRepository;
            _corporateCustomerCorporateDealerCommentQueryRepository = corporateCustomerCorporateDealerCommentQueryRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _corporateDealerBusinessRules = corporateDealerBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateCorporateCustomerCorporateDealerCommentCommandResponse> Handle(CreateCorporateCustomerCorporateDealerCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetByIdAsync(request.CorporateCustomerId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var corporateDealer = await _corporateDealerQueryRepository.GetByIdAsync(request.CorporateDealerId);

            await _corporateDealerBusinessRules.NullCheck(corporateDealer);
            await _corporateDealerBusinessRules.CheckIfCorporateDealerAccountActiveOnCommenting(corporateDealer);

            var corporateDealerComment = await _corporateCustomerCorporateDealerCommentQueryRepository.GetSingleAsync(e => e.CorporateCustomerId == request.CorporateCustomerId && e.CorporateDealerId == request.CorporateDealerId && e.Content == request.CommentContent && e.Title == request.CommentTitle);

            await _evaluationBusinessRules.ExistsCheck(corporateDealerComment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.CorporateCustomerCorporateDealerCommentExchangeName,
                                               exchangeType: RabbitMQConstants.DefaultExchangeType,
                                               queueName: RabbitMQConstants.CreateCorporateCustomerCorporateDealerCommentQueueName,
                                               obj: new CreateCorporateCustomerCorporateDealerCommentEvent()
                                               {
                                                   CorporateCustomerId = request.CorporateCustomerId,
                                                   CorporateDealerId = request.CorporateDealerId,
                                                   Content = request.CommentContent,
                                                   Title = request.CommentTitle
                                               });

            var corporateCustomerCorporateDealerCommentDto = _mapper.Map<CorporateCustomerCorporateDealerCommentDto>(request);

            return await Task.FromResult(new CreateCorporateCustomerCorporateDealerCommentCommandResponse(new SuccessfulContentResponse<CorporateCustomerCorporateDealerCommentDto>(corporateCustomerCorporateDealerCommentDto,
                                                                                  ResponseTitles.Success,
                                                                                  ResponseMessages.CommentCreated,
                                                                                  HttpStatusCode.Created)));

        }
    }
}
