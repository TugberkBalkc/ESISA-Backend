using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory
{
    public class UpdateMainCategoryCommandHandler : IRequestHandler<UpdateMainCategoryCommandRequest, UpdateMainCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly CategoryBusinessRules _categroryBusinessRules;
        private readonly IMapper _mapper;

        public UpdateMainCategoryCommandHandler
            (ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository,
             CategoryBusinessRules categroryBusinessRules, IMapper mapper)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;         
            _categroryBusinessRules = categroryBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateMainCategoryCommandResponse> Handle(UpdateMainCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categroryBusinessRules.NullCheckByCategroyId(request.CategoryId);

            var category = await _categoryQueryRepository.GetByIdAsync(request.CategoryId);

            _mapper.Map(request, category);

            _categoryCommandRepository.Update(category);

            await _categoryCommandRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return new UpdateMainCategoryCommandResponse(new SuccessfulContentResponse<CategoryDto>(categoryDto, ResponseTitles.Success, ResponseMessages.CategoryUpdated, System.Net.HttpStatusCode.OK));
        }
    }
}

   
