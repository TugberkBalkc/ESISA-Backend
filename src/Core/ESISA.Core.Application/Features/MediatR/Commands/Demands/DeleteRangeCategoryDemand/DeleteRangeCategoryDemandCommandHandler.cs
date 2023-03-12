using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeCategoryDemand
{
    public class DeleteRangeCategoryDemandCommandHandler : IRequestHandler<DeleteRangeCategoryDemandCommandRequest, DeleteRangeCategoryDemandCommandResponse>
    {
        private readonly ICategoryDemandCommandRepository _cateogryDemandCommandRepository;
        private readonly ICategoryDemandQueryRepository _cateogryDemandQueryRepository;
        private readonly CategoryDemandBusinessRules _cateogryDemandBusinessRules;

        public DeleteRangeCategoryDemandCommandHandler
            (ICategoryDemandCommandRepository categoryDemandCommandRepository, ICategoryDemandQueryRepository categoryDemandQueryRepository, CategoryDemandBusinessRules categoryDemandBusinessRules)
        {
            _cateogryDemandCommandRepository = categoryDemandCommandRepository;
            _cateogryDemandQueryRepository = categoryDemandQueryRepository;
            _cateogryDemandBusinessRules = categoryDemandBusinessRules;
        }

        public async Task<DeleteRangeCategoryDemandCommandResponse> Handle(DeleteRangeCategoryDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var cateogryDemandsToCheck = new List<CategoryDemand>();

            foreach (var id in request.CategoryDemandIds)
            {
                cateogryDemandsToCheck.Add(await _cateogryDemandQueryRepository.GetByIdAsync(id));
            }

            await _cateogryDemandBusinessRules.NullCheck(cateogryDemandsToCheck);

            await _cateogryDemandCommandRepository.DeleteRangeAsync(request.CategoryDemandIds);

            await _cateogryDemandCommandRepository.SaveChangesAsync();

            return new DeleteRangeCategoryDemandCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.DemandsDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
