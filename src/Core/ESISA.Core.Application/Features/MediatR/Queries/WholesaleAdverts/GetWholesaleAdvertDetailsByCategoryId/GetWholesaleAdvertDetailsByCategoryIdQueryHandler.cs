using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.WholesaleAdverts.GetWholesaleAdvertDetailsByCategoryId
{
    public class GetWholesaleAdvertDetailsByCategoryIdQueryHandler : IRequestHandler<GetWholesaleAdvertDetailsByCategoryIdQueryRequest, GetWholesaleAdvertDetailsByCategoryIdQueryResponse>
    {
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetWholesaleAdvertDetailsByCategoryIdQueryHandler(IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, IMapper mapper)
        {
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetWholesaleAdvertDetailsByCategoryIdQueryResponse> Handle(GetWholesaleAdvertDetailsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var wholesaleAdverts = _wholesaleAdvertQueryRepository.GetWhereIncluded(e => e.Product.CategoryId == request.CategoryId, false, null);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdverts);

            var wholesaleAdvertDetailsDtos = wholesaleAdverts.Select(e => _mapper.Map<WholesaleAdvertDetailsDto>(e));

            var paginate = wholesaleAdvertDetailsDtos.ToPaginate<WholesaleAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetWholesaleAdvertDetailsByCategoryIdQueryResponse(new SuccessfulContentResponse<IPaginate<WholesaleAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.WholesaleAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
