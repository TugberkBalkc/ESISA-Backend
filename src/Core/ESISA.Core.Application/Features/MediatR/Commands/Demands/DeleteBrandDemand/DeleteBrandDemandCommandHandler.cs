using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteBrandDemand
{
    public class DeleteBrandDemandCommandHandler : IRequestHandler<DeleteBrandDemandCommandRequest, DeleteBrandDemandCommandResponse>
    {
        private readonly IBrandDemandCommandRepository _brandDemandCommandRepository;
        private readonly BrandDemandBusinessRules _brandDemandBusinessRules;

        public DeleteBrandDemandCommandHandler
            (IBrandDemandCommandRepository brandDemandCommandRepository, BrandDemandBusinessRules brandDemandBusinessRules)
        {
            _brandDemandCommandRepository = brandDemandCommandRepository;
            _brandDemandBusinessRules = brandDemandBusinessRules;
        }

        public async Task<DeleteBrandDemandCommandResponse> Handle(DeleteBrandDemandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandDemandBusinessRules.CheckIfBrandDemandNull(request.BrandDemandId);

            await _brandDemandCommandRepository.DeleteAsync(request.BrandDemandId);

            await _brandDemandCommandRepository.SaveChangesAsync();

            return new DeleteBrandDemandCommandResponse(new SuccessfulContentResponse<Guid>(request.BrandDemandId, ResponseTitles.Success, ResponseMessages.DemandDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
