using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsByProductId
{
    public class GetSwapAdvertDetailsByProductIdQueryHandler : IRequestHandler<GetSwapAdvertDetailsByProductIdQueryRequest, GetSwapAdvertDetailsByProductIdQueryResponse>
    {
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetSwapAdvertDetailsByProductIdQueryHandler(ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IMapper mapper)
        {
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetSwapAdvertDetailsByProductIdQueryResponse> Handle(GetSwapAdvertDetailsByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            var swapAdverts = _swapAdvertQueryRepository.GetWhereIncluded(e => e.ProductId == request.ProductId, false, null);

            await _swapAdvertBusinessRules.NullCheck(swapAdverts);

            var swapAdvertDetailsDtos = swapAdverts.Select(e => _mapper.Map<SwapAdvertDetailsDto>(e));

            var paginate = swapAdvertDetailsDtos.ToPaginate<SwapAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetSwapAdvertDetailsByProductIdQueryResponse(new SuccessfulContentResponse<IPaginate<SwapAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.SwapAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
