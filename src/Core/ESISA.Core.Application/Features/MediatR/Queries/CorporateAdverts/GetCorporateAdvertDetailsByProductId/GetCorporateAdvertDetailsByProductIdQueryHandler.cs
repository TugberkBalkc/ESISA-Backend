﻿using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByProductId
{
    public class GetCorporateAdvertDetailsByProductIdQueryHandler : IRequestHandler<GetCorporateAdvertDetailsByProductIdQueryRequest, GetCorporateAdvertDetailsByProductIdQueryResponse>
    {
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetCorporateAdvertDetailsByProductIdQueryHandler(ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetCorporateAdvertDetailsByProductIdQueryResponse> Handle(GetCorporateAdvertDetailsByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            var corporateAdverts = _corporateAdvertQueryRepository.GetWhereIncluded(e => e.ProductId == request.ProductId, false, null);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdverts);

            var corporateAdvertDetailsDtos = corporateAdverts.Select(e => _mapper.Map<CorporateAdvertDetailsDto>(e));

            var paginate = corporateAdvertDetailsDtos.ToPaginate<CorporateAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return new GetCorporateAdvertDetailsByProductIdQueryResponse(new SuccessfulContentResponse<IPaginate<CorporateAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.CorporateAdvertsListed, System.Net.HttpStatusCode.OK));

        }
    }
}
