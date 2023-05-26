using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.WholesaleAdverts.GetWholesaleAdvertDetailsByBrandId
{
    public class GetWholesaleAdvertDetailsByBrandIdQueryHandler : IRequestHandler<GetWholesaleAdvertDetailsByBrandIdQueryRequest, GetWholesaleAdvertDetailsByBrandIdQueryResponse>
    {
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetWholesaleAdvertDetailsByBrandIdQueryHandler(IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, IMapper mapper)
        {
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetWholesaleAdvertDetailsByBrandIdQueryResponse> Handle(GetWholesaleAdvertDetailsByBrandIdQueryRequest request, CancellationToken cancellationToken)
        {
            var wholesaleAdverts = _wholesaleAdvertQueryRepository.GetWhereIncluded(e=>e.Product.BrandId == request.BrandId, false, null);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdverts);

            var wholesaleAdvertDetailsDtos = wholesaleAdverts.Select(e => _mapper.Map<WholesaleAdvertDetailsDto>(e));

            var paginate = wholesaleAdvertDetailsDtos.ToPaginate<WholesaleAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetWholesaleAdvertDetailsByBrandIdQueryResponse(new SuccessfulContentResponse<IPaginate<WholesaleAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.WholesaleAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
