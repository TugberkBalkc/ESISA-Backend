using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Extensions;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommandRequest, CreateSubCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IMapper _mapper;

        public CreateSubCategoryCommandHandler
            (ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, CategoryBusinessRules categoryBusinessRules,
             IMapper mapper)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _categoryBusinessRules = categoryBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateSubCategoryCommandResponse> Handle(CreateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryToCheck = await _categoryQueryRepository.GetSingleAsync(e => e.Name == request.CategoryName);

            await _categoryBusinessRules.ExistsCheck(categoryToCheck);

            var category = _mapper.Map<Category>(request);

            await _categoryCommandRepository.AddAsync(category);

            await _categoryCommandRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return new CreateSubCategoryCommandResponse(new SuccessfulContentResponse<CategoryDto>(categoryDto, ResponseTitles.Success, ResponseMessages.SubCategoryCreated, System.Net.HttpStatusCode.OK));
        }
    }
}
