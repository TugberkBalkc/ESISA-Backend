using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteCategoryDemand
{
    public class DeleteCategoryDemandCommandHandler : IRequestHandler<DeleteCategoryDemandCommandRequest, DeleteCategoryDemandCommandResponse>
    {
        private readonly ICategoryDemandCommandRepository _categoryDemandCommandRepository;
        private readonly ICategoryDemandQueryRepository _categoryDemandQueryRepository;
        private readonly CategoryDemandBusinessRules _categoryDemandBusinessRules;

        public DeleteCategoryDemandCommandHandler
            (ICategoryDemandCommandRepository categoryDemandCommandRepository, ICategoryDemandQueryRepository categoryDemandQueryRepository, CategoryDemandBusinessRules categoryDemandBusinessRules)
        {
            _categoryDemandCommandRepository = categoryDemandCommandRepository;
            _categoryDemandQueryRepository = categoryDemandQueryRepository;
            _categoryDemandBusinessRules = categoryDemandBusinessRules;
        }

        public async Task<DeleteCategoryDemandCommandResponse> Handle(DeleteCategoryDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryDemandToCheck = await _categoryDemandQueryRepository.GetByIdAsync(request.CategoryDemandId);

            await _categoryDemandBusinessRules.NullCheck(categoryDemandToCheck);

            await _categoryDemandCommandRepository.DeleteAsync(request.CategoryDemandId);

            await _categoryDemandCommandRepository.SaveChangesAsync();

            return new DeleteCategoryDemandCommandResponse(new SuccessfulContentResponse<Guid>(request.CategoryDemandId, ResponseTitles.Success, ResponseMessages.DemandDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
