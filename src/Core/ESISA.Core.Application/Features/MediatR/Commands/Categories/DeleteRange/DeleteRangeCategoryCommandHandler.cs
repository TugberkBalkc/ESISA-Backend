using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.DeleteRange
{
    public class DeleteRangeCategoryCommandHandler : IRequestHandler<DeleteRangeCategoryCommandRequest, DeleteRangeCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public DeleteRangeCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<DeleteRangeCategoryCommandResponse> Handle(DeleteRangeCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var categoriesToCheck = new List<Category>();

            request.CategoryIds.ToList().ForEach(async id =>
            {
                categoriesToCheck.Add(await _categoryQueryRepository.GetByIdAsync(id));
            });

            await _categoryBusinessRules.NullCheck(categoriesToCheck.ToArray());

            await _categoryCommandRepository.DeleteRangeAsync(request.CategoryIds);

            await _categoryCommandRepository.SaveChangesAsync();

            return new DeleteRangeCategoryCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.CategoriesDeleted, System.Net.HttpStatusCode.OK));

        }
    }
}
