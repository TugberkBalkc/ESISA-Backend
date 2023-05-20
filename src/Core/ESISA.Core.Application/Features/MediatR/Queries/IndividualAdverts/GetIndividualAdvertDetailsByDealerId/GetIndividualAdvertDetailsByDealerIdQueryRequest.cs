using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByCategoryId;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.Common;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByDealerId
{
    public class GetIndividualAdvertDetailsByDealerIdQueryRequest : IRequest<GetIndividualAdvertDetailsByDealerIdQueryResponse>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid IndividualDealerId { get; set; }

        public GetIndividualAdvertDetailsByDealerIdQueryRequest()
        {

        }

        public GetIndividualAdvertDetailsByDealerIdQueryRequest(int pageIndex, int pageSize, Guid individualDealerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndividualDealerId = individualDealerId;
        }
    }

    public class GetIndividualAdvertDetailsByDealerIdQueryResponse : PluralQueryResponse<IndividualAdvertDetailsDto>
    {
        public GetIndividualAdvertDetailsByDealerIdQueryResponse(IContentResponse<IPaginate<IndividualAdvertDetailsDto>> response) : base(response)
        {
        }
    }

    public class GetIndividualAdvertDetailsByDealerIdQueryHandler : IRequestHandler<GetIndividualAdvertDetailsByDealerIdQueryRequest, GetIndividualAdvertDetailsByDealerIdQueryResponse>
    {
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;
        private readonly IMapper _mapper;

        public GetIndividualAdvertDetailsByDealerIdQueryHandler(IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IMapper mapper)
        {
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetIndividualAdvertDetailsByDealerIdQueryResponse> Handle(GetIndividualAdvertDetailsByDealerIdQueryRequest request, CancellationToken cancellationToken)
        {
            var individualAdverts = _individualAdvertQueryRepository.GetWhereIncluded(e => e.IndividualDealerId == request.IndividualDealerId, false, null);

            var individualAdvertDetailsDtos = individualAdverts.Select(e => _mapper.Map<IndividualAdvertDetailsDto>(e));

            var paginate = individualAdvertDetailsDtos.ToPaginate<IndividualAdvertDetailsDto>(request.PageIndex, request.PageSize);

            return await Task.FromResult(new GetIndividualAdvertDetailsByDealerIdQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualAdvertDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.IndividualAdvertsListed, System.Net.HttpStatusCode.OK)));
        }
    }
}
