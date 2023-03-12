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
        private readonly IBrandDemandQueryRepository _brandDemandQueryRepository;
        private readonly BrandDemandBusinessRules _brandDemandBusinessRules;

        public DeleteBrandDemandCommandHandler
            (IBrandDemandCommandRepository brandDemandCommandRepository, IBrandDemandQueryRepository brandDemandQueryRepository, BrandDemandBusinessRules brandDemandBusinessRules)
        {
            _brandDemandCommandRepository = brandDemandCommandRepository;
            _brandDemandQueryRepository = brandDemandQueryRepository;
            _brandDemandBusinessRules = brandDemandBusinessRules;
        }

        public async Task<DeleteBrandDemandCommandResponse> Handle(DeleteBrandDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var brandDemandToCheck = await _brandDemandQueryRepository.GetByIdAsync(request.BrandDemandId);

            await _brandDemandBusinessRules.NullCheck(brandDemandToCheck);

            await _brandDemandCommandRepository.DeleteAsync(request.BrandDemandId);

            await _brandDemandCommandRepository.SaveChangesAsync();

            return new DeleteBrandDemandCommandResponse(new SuccessfulContentResponse<Guid>(request.BrandDemandId, ResponseTitles.Success, ResponseMessages.DemandDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
