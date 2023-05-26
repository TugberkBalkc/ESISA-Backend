using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Addresses.Delete
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        private readonly IAddressCommandRepository _addressCommandRepository;
        private readonly IAddressQueryRepository _addressQueryRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public DeleteAddressCommandHandler(IAddressCommandRepository addressCommandRepository, IAddressQueryRepository addressQueryRepository, AddressBusinessRules addressBusinessRules)
        {
            _addressCommandRepository = addressCommandRepository;
            _addressQueryRepository = addressQueryRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var address = await _addressQueryRepository.GetByIdAsync(request.AddressId);

            await _addressBusinessRules.NullCheck(address);

            _addressCommandRepository.Delete(address);
            await _addressCommandRepository.SaveChangesAsync();

            return new DeleteAddressCommandResponse(new SuccessfulContentResponse<Guid>(address.Id, ResponseTitles.Success, ResponseMessages.AddressDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
