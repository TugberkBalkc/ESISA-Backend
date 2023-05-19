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

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateIndivdualDealerComment
{
    public class CreateIndividualCustomerIndividualDealerCommentCommandHandler : IRequestHandler<CreateIndividualCustomerIndividualDealerCommentCommandRequest, CreateIndividualCustomerIndividualDealerCommentCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly IIndividualDealerQueryRepository _individualDealerQueryRepository;
        private readonly IIndividualCustomerIndividualDealerCommentQueryRepository _individualCustomerIndividualDealerCommentQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;       
        private readonly EvaluationBusinessRules _evaluationBusinessRules;
        private readonly IMapper _mapper;

        public CreateIndividualCustomerIndividualDealerCommentCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, IIndividualDealerQueryRepository individualDealerQueryRepository, IIndividualCustomerIndividualDealerCommentQueryRepository individualCustomerIndividualDealerCommentQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _individualDealerQueryRepository = individualDealerQueryRepository;
            _individualCustomerIndividualDealerCommentQueryRepository = individualCustomerIndividualDealerCommentQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateIndividualCustomerIndividualDealerCommentCommandResponse> Handle(CreateIndividualCustomerIndividualDealerCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var individualDealer = await _individualDealerQueryRepository.GetByIdAsync(request.IndividualDealerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);
            await _individualStarterBusinessRules.CheckIfIndividualDealerAccountActiveOnCommenting(individualDealer);

            var individualDealerComment = await _individualCustomerIndividualDealerCommentQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.IndividualDealerId == request.IndividualDealerId && e.Title == request.CommentTitle && e.Content == request.CommentContent);

            await _evaluationBusinessRules.ExistsCheck(individualDealerComment);

            RabbitMQFactory.SendMessageToExchange(exchangeName:RabbitMQConstants.IndividualCustomerIndividualDealerCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName:          RabbitMQConstants.CreateIndividualCustomerIndividualDealerCommentQueueName,
                                                  obj: new CreateIndividualCustomerIndividualDealerCommentEvent()
                                                  {
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      IndividualDealerId = request.IndividualDealerId,
                                                      Content = request.CommentContent,
                                                      Title = request.CommentTitle
                                                  });

            var individualCustomerIndividualDealerCommentDto = _mapper.Map<IndividualCustomerIndividualDealerCommentDto>(request);

            return await Task.FromResult(new CreateIndividualCustomerIndividualDealerCommentCommandResponse(new SuccessfulContentResponse<IndividualCustomerIndividualDealerCommentDto>(individualCustomerIndividualDealerCommentDto,
                                                                                  ResponseTitles.Success,
                                                                                  ResponseMessages.CommentCreated,
                                                                                  HttpStatusCode.Created)));
        }
    }
}
