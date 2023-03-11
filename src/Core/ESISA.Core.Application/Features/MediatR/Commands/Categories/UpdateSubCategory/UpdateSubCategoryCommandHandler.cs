using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Update
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommandRequest, UpdateSubCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IMapper _mapper;

        public UpdateSubCategoryCommandHandler
            (ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository,
             CategoryBusinessRules categoryBusinessRules, IMapper mapper)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _categoryBusinessRules = categoryBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateSubCategoryCommandResponse> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            await _categoryBusinessRules.NullCheckByCategroyId(request.CategoryId);

            var category = await _categoryQueryRepository.GetByIdAsync(request.CategoryId);

            _mapper.Map(request, category);

            _categoryCommandRepository.Update(category);

            await _categoryCommandRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return new UpdateSubCategoryCommandResponse(new SuccessfulContentResponse<CategoryDto>(categoryDto, ResponseTitles.Success, ResponseMessages.CategoryUpdated, System.Net.HttpStatusCode.OK));
        }
    }
}
