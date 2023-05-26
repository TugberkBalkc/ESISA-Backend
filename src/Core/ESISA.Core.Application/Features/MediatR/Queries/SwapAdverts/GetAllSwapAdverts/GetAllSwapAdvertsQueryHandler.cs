using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetAllSwapAdverts
{
    public class GetAllSwapAdvertsQueryHandler : IRequestHandler<GetAllSwapAdvertsQueryRequest, GetAllSwapAdvertsQueryResponse>
    {
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetAllSwapAdvertsQueryHandler(ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IMapper mapper)
        {
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllSwapAdvertsQueryResponse> Handle(GetAllSwapAdvertsQueryRequest request, CancellationToken cancellationToken)
        {
            var swapAdverts = _swapAdvertQueryRepository.GetAll(false, null, e=>e.Advert);

            await _swapAdvertBusinessRules.NullCheck(swapAdverts);

            var swapAdvertDtos = swapAdverts.Select(e => _mapper.Map<SwapAdvertDto>(e));

            var paginate = swapAdvertDtos.ToPaginate<SwapAdvertDto>(request.PageIndex, request.PageSize);

            return new GetAllSwapAdvertsQueryResponse(new SuccessfulContentResponse<IPaginate<SwapAdvertDto>>(paginate, ResponseTitles.Success, ResponseMessages.SwapAdvertsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
