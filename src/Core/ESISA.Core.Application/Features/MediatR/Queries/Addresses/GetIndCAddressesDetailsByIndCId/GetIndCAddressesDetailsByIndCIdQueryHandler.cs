using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetIndCAddressesDetailsByIndCId
{
    public class GetIndCAddressesDetailsByIndCIdQueryHandler : IRequestHandler<GetIndCAddressesDetailsByIndCIdQueryRequest, GetIndCAddressesDetailsByIndCIdQueryResponse>
    {
        private readonly IIndividualCustomerAddressQueryRepository _individualCustomerAddressQueryRepository;
        private readonly IndividualCustomerAddressBusinessRules _individualCustomerAddressBusinessRules;
        private readonly IMapper _mapper;

        public GetIndCAddressesDetailsByIndCIdQueryHandler
            (IIndividualCustomerAddressQueryRepository individualCustomerAddressQueryRepository, IndividualCustomerAddressBusinessRules individualCustomerAddressBusinessRules, 
             IMapper mapper)
        {
            _individualCustomerAddressQueryRepository = individualCustomerAddressQueryRepository;
            _individualCustomerAddressBusinessRules = individualCustomerAddressBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetIndCAddressesDetailsByIndCIdQueryResponse> Handle(GetIndCAddressesDetailsByIndCIdQueryRequest request, CancellationToken cancellationToken)
        {
            var individualCustomerAddressDetailsDtos = _individualCustomerAddressQueryRepository
                                                             .GetWhere(e => e.IndividualCustomerId == request.IndividualCustomerId, false, null, e => e.IndividualCustomer, e => e.Address, e => e.Address.City, e => e.Address.District, e => e.Address.Country)
                                                             .Select(e=> _mapper.Map<IndividualCustomerAddressDetailsDto>(e));

            await _individualCustomerAddressBusinessRules.NullCheck(individualCustomerAddressDetailsDtos);

            var paginate = individualCustomerAddressDetailsDtos.ToPaginate<IndividualCustomerAddressDetailsDto>(request.PageIndex, request.PageSize);

            return new GetIndCAddressesDetailsByIndCIdQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualCustomerAddressDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.AddressesListed, System.Net.HttpStatusCode.OK));
        }
    }
}
