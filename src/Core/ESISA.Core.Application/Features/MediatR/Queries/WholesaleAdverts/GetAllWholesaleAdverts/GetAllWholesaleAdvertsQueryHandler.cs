using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.WholesaleAdverts.GetAllWholesaleAdverts
{
    public class GetAllWholesaleAdvertsQueryHandler : IRequestHandler<GetAllWholesaleAdvertsQueryRequest, GetAllWholesaleAdvertsQueryResponse>
    {
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetAllWholesaleAdvertsQueryHandler(IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, IMapper mapper)
        {
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllWholesaleAdvertsQueryResponse> Handle(GetAllWholesaleAdvertsQueryRequest request, CancellationToken cancellationToken)
        {
            var wholesaleAdverts = _wholesaleAdvertQueryRepository.GetAll(false, null, e => e.Advert);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdverts);

            var wholesaleAdvertDtos = wholesaleAdverts.Select(e => _mapper.Map<WholesaleAdvertDto>(e));

            var paginate = wholesaleAdvertDtos.ToPaginate<WholesaleAdvertDto>(request.PageIndex, request.PageSize);

            return new GetAllWholesaleAdvertsQueryResponse(new SuccessfulContentResponse<IPaginate<WholesaleAdvertDto>>(paginate, ResponseTitles.Success, ResponseMessages.SwapAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
