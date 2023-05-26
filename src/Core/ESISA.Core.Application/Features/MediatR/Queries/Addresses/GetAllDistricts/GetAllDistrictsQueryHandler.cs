using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCountries;
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

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistricts
{
    public class GetAllDistrictsQueryHandler : IRequestHandler<GetAllDistrictsQueryRequest, GetAllDistrictsQueryResponse>
    {

        private readonly IDistrictQueryRepository _districtQueryRepository;
        private readonly IMapper _mapper;
        private readonly DistrictBusinessRules _districtBusinessRules;
      

        public GetAllDistrictsQueryHandler()
        {

        }
        public GetAllDistrictsQueryHandler(IDistrictQueryRepository districtQueryRepository, IMapper mapper,DistrictBusinessRules districtBusinessRules)
        {
            _districtQueryRepository = districtQueryRepository;
            _mapper = mapper;
            _districtBusinessRules = districtBusinessRules;
        }
        public async Task<GetAllDistrictsQueryResponse> Handle(GetAllDistrictsQueryRequest request, CancellationToken cancellationToken)
        {
            var districtDtos = _districtQueryRepository.GetAll().OrderBy(e => e.Name).Select(e => _mapper.Map<DistrictDto>(e));

            await _districtBusinessRules.NullCheck(districtDtos);

            var paginate = districtDtos.ToPaginate<DistrictDto>(request.PageIndex, request.PageSize);

            return new GetAllDistrictsQueryResponse(new SuccessfulContentResponse<IPaginate<DistrictDto>>(paginate, ResponseTitles.Success, "", System.Net.HttpStatusCode.OK));
        }
    }
}
