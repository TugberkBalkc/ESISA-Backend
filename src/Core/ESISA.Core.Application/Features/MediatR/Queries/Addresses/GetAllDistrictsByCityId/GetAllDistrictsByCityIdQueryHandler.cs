using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistricts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistrictsByCityId
{
    public class GetAllDistrictsByCityIdQueryHandler : IRequestHandler<GetAllDistrictsByCityIdQueryRequest, GetAllDistrictsByCityIdQueryResponse>
    {

        private readonly IDistrictQueryRepository _districtQueryRepository;
        private readonly IMapper _mapper;
        private readonly DistrictBusinessRules _districtBusinessRules;


        public GetAllDistrictsByCityIdQueryHandler()
        {

        }
        public GetAllDistrictsByCityIdQueryHandler(IDistrictQueryRepository districtQueryRepository, IMapper mapper, DistrictBusinessRules districtBusinessRules)
        {
            _districtQueryRepository = districtQueryRepository;
            _mapper = mapper;
            _districtBusinessRules = districtBusinessRules;
        }
        public async Task<GetAllDistrictsByCityIdQueryResponse> Handle(GetAllDistrictsByCityIdQueryRequest request, CancellationToken cancellationToken)
        {
            var districtDtos = _districtQueryRepository.GetAll()
                .Where(e=>e.CityId==request.CityId)
                .OrderBy(e => e.Name).Select(e => _mapper.Map<DistrictDto>(e));

            await _districtBusinessRules.NullCheck(districtDtos);

            var paginate = districtDtos.ToPaginate<DistrictDto>(request.PageIndex, request.PageSize);

            return new GetAllDistrictsByCityIdQueryResponse(new SuccessfulContentResponse<IPaginate<DistrictDto>>(paginate, ResponseTitles.Success, "", System.Net.HttpStatusCode.OK));
        }
    }
}
