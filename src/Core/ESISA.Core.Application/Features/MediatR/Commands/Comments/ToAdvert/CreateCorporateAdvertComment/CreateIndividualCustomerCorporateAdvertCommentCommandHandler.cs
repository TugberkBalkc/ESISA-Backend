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

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateCorporateAdvertComment
{
    public class CreateIndividualCustomerCorporateAdvertCommentCommandHandler : IRequestHandler<CreateIndividualCustomerCorporateAdvertCommentCommandRequest, CreateIndividualCustomerCorporateAdvertCommentCommandResponse>
    {
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly IIndividualCustomerCorporateAdvertCommentQueryRepository _individualCustomerCorporateAdvertCommentQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly EvaluationBusinessRules _evaluationBusinessRules;      
        private readonly IMapper _mapper;

        public CreateIndividualCustomerCorporateAdvertCommentCommandHandler(IIndividualCustomerQueryRepository individualCustomerQueryRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, IIndividualCustomerCorporateAdvertCommentQueryRepository individualCustomerCorporateAdvertCommentQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, CorporateAdvertBusinessRules corporateAdvertBusinessRules, EvaluationBusinessRules evaluationBusinessRules, IMapper mapper)
        {
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _individualCustomerCorporateAdvertCommentQueryRepository = individualCustomerCorporateAdvertCommentQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _evaluationBusinessRules = evaluationBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateIndividualCustomerCorporateAdvertCommentCommandResponse> Handle(CreateIndividualCustomerCorporateAdvertCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var corporateAdvert = await _corporateAdvertQueryRepository.GetByIdAsync(request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);

            var corporateAdvertComment = await _individualCustomerCorporateAdvertCommentQueryRepository.GetSingleAsync(e => e.IndividualCustomerId == request.IndividualCustomerId && e.CorporateAdvertId == request.CorporateAdvertId && e.Title == request.CommentTitle && e.Content == request.CommentContent);

            await _evaluationBusinessRules.ExistsCheck(corporateAdvertComment, ResponseMessages.Comment);

            RabbitMQFactory.SendMessageToExchange(exchangeName: RabbitMQConstants.IndividualCustomerCorporateAdvertCommentExchangeName,
                                                  exchangeType: RabbitMQConstants.DefaultExchangeType,
                                                  queueName: RabbitMQConstants.CreateIndividualCustomerCorporateAdvertCommentQueueName,
                                                  obj: new CreateIndividualCustomerCorporateAdvertCommentEvent()
                                                  {
                                                      CorporateAdvertId = request.CorporateAdvertId,
                                                      IndividualCustomerId = request.IndividualCustomerId,
                                                      Content = request.CommentContent,
                                                      Title = request.CommentTitle
                                                  });

            var individualCustomerCorporateAdvertCommentDto = _mapper.Map<IndividualCustomerCorporateAdvertCommentDto>(request);

            return await Task.FromResult(new CreateIndividualCustomerCorporateAdvertCommentCommandResponse(new SuccessfulContentResponse<IndividualCustomerCorporateAdvertCommentDto>(individualCustomerCorporateAdvertCommentDto,
                                                                                     ResponseTitles.Success,
                                                                                     ResponseMessages.CommentCreated,
                                                                                     HttpStatusCode.Created)));
        }
    }
}
