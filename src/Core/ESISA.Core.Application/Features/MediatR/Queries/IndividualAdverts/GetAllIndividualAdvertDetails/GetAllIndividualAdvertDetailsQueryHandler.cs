using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Advert;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdvertDetails
{
    public class GetAllIndividualAdvertDetailsQueryHandler : IRequestHandler<GetAllIndividualAdvertDetailsQueryRequest, GetAllIndividualAdvertDetailsQueryResponse>
    {
        private readonly IAdvertService _advertService;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetAllIndividualAdvertDetailsQueryHandler(IAdvertService advertService, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IMapper mapper)
        {
            _advertService = advertService;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllIndividualAdvertDetailsQueryResponse> Handle(GetAllIndividualAdvertDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var individualAdverts = _individualAdvertQueryRepository.GetAllIncluded(false, null);

            await _individualAdvertBusinessRules.NullCheck(individualAdverts);

            var individualAdvertDetailsDtos = individualAdverts.Select(e => _mapper.Map<IndividualAdvertDetailsDto>(e));

            var paginate = individualAdvertDetailsDtos.ToPaginate<IndividualAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetAllIndividualAdvertDetailsQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.IndividualAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
