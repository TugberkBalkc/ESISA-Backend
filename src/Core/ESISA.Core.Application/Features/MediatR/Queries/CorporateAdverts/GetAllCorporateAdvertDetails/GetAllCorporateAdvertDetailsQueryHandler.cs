using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetAllCorporateAdvertDetails
{
    public class GetAllCorporateAdvertDetailsQueryHandler : IRequestHandler<GetAllCorporateAdvertDetailsQueryRequest, GetAllCorporateAdvertDetailsQueryResponse>
    {
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetAllCorporateAdvertDetailsQueryHandler(ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllCorporateAdvertDetailsQueryResponse> Handle(GetAllCorporateAdvertDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var corporateAdverts = _corporateAdvertQueryRepository.GetAllIncluded(false, null);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdverts);

            var corporateAdvertDetailsDtos = corporateAdverts.Select(e => _mapper.Map<CorporateAdvertDetailsDto>(e));

            var paginate = corporateAdvertDetailsDtos.ToPaginate<CorporateAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetAllCorporateAdvertDetailsQueryResponse(new SuccessfulContentResponse<IPaginate<CorporateAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.CorporateAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
