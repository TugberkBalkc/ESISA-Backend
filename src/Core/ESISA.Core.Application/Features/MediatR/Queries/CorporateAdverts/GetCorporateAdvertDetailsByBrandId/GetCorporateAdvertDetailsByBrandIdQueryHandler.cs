using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByBrandId
{
    public class GetCorporateAdvertDetailsByBrandIdQueryHandler : IRequestHandler<GetCorporateAdvertDetailsByBrandIdQueryRequest, GetCorporateAdvertDetailsByBrandIdQueryResponse>
    {
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetCorporateAdvertDetailsByBrandIdQueryHandler(ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetCorporateAdvertDetailsByBrandIdQueryResponse> Handle(GetCorporateAdvertDetailsByBrandIdQueryRequest request, CancellationToken cancellationToken)
        {
            var corporateAdverts = _corporateAdvertQueryRepository.GetWhereIncluded(e=>e.Product.BrandId == request.BrandId, false, null);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdverts);

            var corporateAdvertDetailsDtos = corporateAdverts.Select(e => _mapper.Map<CorporateAdvertDetailsDto>(e));

            var paginate = corporateAdvertDetailsDtos.ToPaginate<CorporateAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetCorporateAdvertDetailsByBrandIdQueryResponse(new SuccessfulContentResponse<IPaginate<CorporateAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.CorporateAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
