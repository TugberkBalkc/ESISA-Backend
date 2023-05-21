using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Advert;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.DynamicQuerying.Extensions;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByDynamic
{
    public class GetIndividualAdvertDetailsByDynamicQueryHandler : IRequestHandler<GetIndividualAdvertDetailsByDynamicQueryRequest, GetIndividualAdvertDetailsByDynamicQueryResponse>
    {
        private readonly IAdvertService _advertService;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetIndividualAdvertDetailsByDynamicQueryHandler(IAdvertService advertService, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IMapper mapper)
        {
            _advertService = advertService;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            _mapper = mapper;
        }
        public async Task<GetIndividualAdvertDetailsByDynamicQueryResponse> Handle(GetIndividualAdvertDetailsByDynamicQueryRequest request, CancellationToken cancellationToken)
        {
            var individualAdverts = _individualAdvertQueryRepository.GetAllIncluded(false, null);

            await _individualAdvertBusinessRules.NullCheck(individualAdverts);

            var individualAdvertDetailsDtos = individualAdverts.Select(e => _mapper.Map<IndividualAdvertDetailsDto>(e));

            var dynamicQueried = individualAdvertDetailsDtos.ToDynamic<IndividualAdvertDetailsDto>(request.DynamicQuery);

            var paginate = dynamicQueried.ToPaginate<IndividualAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetIndividualAdvertDetailsByDynamicQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.IndividualAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
