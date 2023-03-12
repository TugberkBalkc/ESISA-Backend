using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeBrandDemand
{
    public class DeleteRangeBrandDemandCommandHandler : IRequestHandler<DeleteRangeBrandDemandCommandRequest, DeleteRangeBrandDemandCommandResponse>
    {
        private readonly IBrandDemandCommandRepository _brandDemandCommandRepository;
        private readonly IBrandDemandQueryRepository _brandDemandQueryRepository;
        private readonly BrandDemandBusinessRules _brandDemandBusinessRules;

        public DeleteRangeBrandDemandCommandHandler
            (IBrandDemandCommandRepository brandDemandCommandRepository, IBrandDemandQueryRepository brandDemandQueryRepository, BrandDemandBusinessRules brandDemandBusinessRules)
        {
            _brandDemandCommandRepository = brandDemandCommandRepository;
            _brandDemandQueryRepository = brandDemandQueryRepository;
            _brandDemandBusinessRules = brandDemandBusinessRules;
        }

        public async Task<DeleteRangeBrandDemandCommandResponse> Handle(DeleteRangeBrandDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var brandDemandsToCheck = new List<BrandDemand>();

            request.BrandDemandIds.ToList().ForEach(async id =>
            {
                brandDemandsToCheck.Add(await _brandDemandQueryRepository.GetByIdAsync(id));
            });

            await _brandDemandBusinessRules.NullCheck(brandDemandsToCheck);

            await _brandDemandCommandRepository.DeleteRangeAsync(request.BrandDemandIds);

            await _brandDemandCommandRepository.SaveChangesAsync();

            return new DeleteRangeBrandDemandCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.DemandsDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
