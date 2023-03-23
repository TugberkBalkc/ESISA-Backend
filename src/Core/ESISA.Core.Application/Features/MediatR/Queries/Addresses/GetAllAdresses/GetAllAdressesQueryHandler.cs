using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
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

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllAdresses
{
    public class GetAllAdressesQueryHandler : IRequestHandler<GetAllAdressesQueryRequest, GetAllAdressesQueryResponse>
    {
        private readonly   IAddressQueryRepository _addressQueryRepository;
        private readonly IMapper _mapper;
        private readonly AdressBusinessRules _adressBusinessRules;

        public GetAllAdressesQueryHandler(IAddressQueryRepository addressQueryRepository, IMapper mapper, AdressBusinessRules adressBusinessRules)
        {
           _addressQueryRepository=addressQueryRepository;
            _mapper=mapper; 
            _adressBusinessRules=adressBusinessRules;   
        }

        public async Task<GetAllAdressesQueryResponse> Handle(GetAllAdressesQueryRequest request, CancellationToken cancellationToken)
        {
            var adressDtos = _addressQueryRepository.GetAll().Select(e => _mapper.Map<AdressDto>(e));

            await _adressBusinessRules.NullCheck(adressDtos);

            var paginate = adressDtos.ToPaginate<AdressDto>(request.PageIndex, request.PageSize);

            return new GetAllAdressesQueryResponse(new SuccessfulContentResponse<IPaginate<AdressDto>>(paginate, ResponseTitles.Success, "", System.Net.HttpStatusCode.OK));
        }
    
    }
}
