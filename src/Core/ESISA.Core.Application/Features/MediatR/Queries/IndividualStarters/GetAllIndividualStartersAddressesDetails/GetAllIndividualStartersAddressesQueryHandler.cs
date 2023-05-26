using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualStarters.GetAllIndividualStartersAddressesDetails
{
    public class GetAllIndividualStartersAddressesDetailsQueryHandler : IRequestHandler<GetAllIndividualStartersAddressesDetailsQueryRequest, GetAllIndividualStartersAddressesDetailsQueryResponse>
    {
        private readonly IAddressQueryRepository _addressQueryRepository;
        private readonly AddressBusinessRules _addressBusinessRules;
        private readonly IMapper _mapper;

        public GetAllIndividualStartersAddressesDetailsQueryHandler(IAddressQueryRepository addressQueryRepository, AddressBusinessRules addressBusinessRules, IMapper mapper)
        {
            _addressQueryRepository = addressQueryRepository;
            _addressBusinessRules = addressBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllIndividualStartersAddressesDetailsQueryResponse> Handle(GetAllIndividualStartersAddressesDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var addresses = _addressQueryRepository.GetAllIncluded( false, null);

            var startersAddresses = addresses.Select(e => e.IndividualCustomerAddresses.Select(e => e.IndividualCustomerId == request.IndividualCustomerId));

            var addressDetailsDtos = addresses.Select(e => _mapper.Map<AddressDetailsDto>(e));

            var paginate = addressDetailsDtos.ToPaginate<AddressDetailsDto>(request.PageIndex, request.PageSize);

            return new GetAllIndividualStartersAddressesDetailsQueryResponse(new SuccessfulContentResponse<IPaginate<AddressDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.AddressesListed, System.Net.HttpStatusCode.OK));
        }
    }
}
