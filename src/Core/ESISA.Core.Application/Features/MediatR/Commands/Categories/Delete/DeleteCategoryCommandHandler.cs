using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        private readonly CategoryBusinessRules _categoryBusinessRules;

        public DeleteCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryToCheck = _categoryQueryRepository.GetByIdAsync(request.CategoryId);

            await _categoryBusinessRules.NullCheck(categoryToCheck);

            await _categoryBusinessRules.CheckIfCategoryHasChildrenById(request.CategoryId,
                async () => {
                    var parentCategory = await _categoryQueryRepository.GetByIdAsync(id: request.CategoryId,
                                                                                     trackingStatus: false,
                                                                                     includes: e=>e.Children);

                    foreach (var child in parentCategory.Children.ToList())
                        await _categoryCommandRepository.DeleteAsync(child.Id);

                    await _categoryCommandRepository.DeleteAsync(request.CategoryId);
                },
                async () => {
                    await _categoryCommandRepository.DeleteAsync(request.CategoryId);
                });
               
            await _categoryCommandRepository.SaveChangesAsync();

            return new DeleteCategoryCommandResponse(new SuccessfulContentResponse<Guid>(request.CategoryId, ResponseTitles.Success, ResponseMessages.CategoryDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
