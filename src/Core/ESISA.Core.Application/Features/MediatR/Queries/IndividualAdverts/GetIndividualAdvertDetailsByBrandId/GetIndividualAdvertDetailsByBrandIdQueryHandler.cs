using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByBrandId
{
    public class GetIndividualAdvertDetailsByBrandIdQueryHandler : IRequestHandler<GetIndividualAdvertDetailsByBrandIdQueryRequest, GetIndividualAdvertDetailsByBrandQueryResponse>
    {
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetIndividualAdvertDetailsByBrandIdQueryHandler(IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IMapper mapper)
        {
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetIndividualAdvertDetailsByBrandQueryResponse> Handle(GetIndividualAdvertDetailsByBrandIdQueryRequest request, CancellationToken cancellationToken)
        {
            var individualAdverts = _individualAdvertQueryRepository.GetWhereIncluded(e => e.Product.BrandId == request.BrandId, false, null);

            await _individualAdvertBusinessRules.NullCheck(individualAdverts);

            var individualAdvertDetailsDtos = individualAdverts.Select(e => _mapper.Map<IndividualAdvertDetailsDto>(e));

            var paginate = individualAdvertDetailsDtos.ToPaginate<IndividualAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetIndividualAdvertDetailsByBrandQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.IndividualAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
