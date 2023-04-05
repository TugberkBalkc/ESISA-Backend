using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndCAddressesByIndCId
{
    public class GetAllIndCAddressesByIndCIdQueryHandler : IRequestHandler<GetAllIndCAddressesByIndCIdQueryRequest, GetAllIndCAddressesByIndCIdQueryResponse>
    {
        private readonly IIndividualCustomerAddressQueryRepository _individualCustomerAddressQueryRepository;
        private readonly IndividualCustomerAddressBusinessRules _individualCustomerAddressBusinessRules;
        private readonly IMapper _mapper;

        public GetAllIndCAddressesByIndCIdQueryHandler
            (IIndividualCustomerAddressQueryRepository individualCustomerAddressQueryRepository, IndividualCustomerAddressBusinessRules individualCustomerAddressBusinessRules,
             IMapper mapper)
        {
            _individualCustomerAddressQueryRepository = individualCustomerAddressQueryRepository;
            _individualCustomerAddressBusinessRules = individualCustomerAddressBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllIndCAddressesByIndCIdQueryResponse> Handle(GetAllIndCAddressesByIndCIdQueryRequest request, CancellationToken cancellationToken)
        {
            var individualCustomerAdressDtos = _individualCustomerAddressQueryRepository
                .GetWhere(e=>e.IndividualCustomerId == request.IndividualCustomerId)
                .Select(e => _mapper.Map<IndividualCustomerAddressDto>(e));

           await _individualCustomerAddressBusinessRules.NullCheck(individualCustomerAdressDtos);

            var paginate = individualCustomerAdressDtos.ToPaginate<IndividualCustomerAddressDto>(request.PageIndex, request.PageSize);

            return new GetAllIndCAddressesByIndCIdQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualCustomerAddressDto>>(paginate, ResponseTitles.Success, ResponseMessages.AddressesListed, System.Net.HttpStatusCode.OK));
        }
    }
}
