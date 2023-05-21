using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetAllCorporateAdverts
{
    public class GetAllCorporateAdvertsQueryHandler : IRequestHandler<GetAllCorporateAdvertsQueryRequest, GetAllCorporateAdvertsQueryResponse>
    {
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetAllCorporateAdvertsQueryHandler(ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllCorporateAdvertsQueryResponse> Handle(GetAllCorporateAdvertsQueryRequest request, CancellationToken cancellationToken)
        {
            var corporateAdverts = _corporateAdvertQueryRepository.GetAll(false, null);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdverts);

            var corporateAdvertDtos = corporateAdverts.Select(e => _mapper.Map<CorporateAdvertDto>(e));

            var paginate = corporateAdvertDtos.ToPaginate<CorporateAdvertDto>(request.PageIndex, request.PageSize);

            return new GetAllCorporateAdvertsQueryResponse(new SuccessfulContentResponse<IPaginate<CorporateAdvertDto>>(paginate, ResponseTitles.Success, ResponseMessages.CorporateAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
