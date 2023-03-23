using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistrictsByCityId;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndividualCustomerAdressesByIndividualCustomerId
{
    public class GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryHandler
        : IRequestHandler<GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest,GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryResponse>
    {
        private readonly IIndividualCustomerAddressQueryRepository _individualCustomerAddressQueryRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerAddressBusinessRules _individualCustomerAddressBusinessRules;
        public GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryHandler()
        {

        }

        public GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryHandler(IIndividualCustomerAddressQueryRepository individualCustomerAddressQueryRepository,
            IMapper mapper, IndividualCustomerAddressBusinessRules individualCustomerAddressBusinessRules)
        {
            _individualCustomerAddressQueryRepository = individualCustomerAddressQueryRepository;
            _mapper = mapper;
            _individualCustomerAddressBusinessRules = individualCustomerAddressBusinessRules;
        }

        public async Task<GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryResponse> Handle(GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest request, CancellationToken cancellationToken)
        {
            var individualCustomerAdressDtos = _individualCustomerAddressQueryRepository.GetAll()
                .Where(e => e.IndividualCustomerId == request.IndividualCustomerId)
                .Select(e => _mapper.Map<IndividualCustomerAddressDetailsDto>(e));

            await _individualCustomerAddressBusinessRules.NullCheck(individualCustomerAdressDtos);

            var paginate = individualCustomerAdressDtos.ToPaginate<IndividualCustomerAddressDetailsDto>(request.PageIndex, request.PageSize);

            return new GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualCustomerAddressDetailsDto>>(paginate, ResponseTitles.Success, "", System.Net.HttpStatusCode.OK));
        }
    }
}
