using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.AddSubCategory
{
    public class AddSubCategoryCommandHandler : IRequestHandler<AddSubCategoryCommandRequest, AddSubCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IMapper _mapper;

        public AddSubCategoryCommandHandler
            (ICategoryCommandRepository categoryCommandRepository, CategoryBusinessRules categoryBusinessRules,
             IMapper mapper)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryBusinessRules = categoryBusinessRules;
            _mapper = mapper;
        }

        public async Task<AddSubCategoryCommandResponse> Handle(AddSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.ExistsCheckByCategoryName(request.CategoryName, "Kategori");

            var category = _mapper.Map<Category>(request);

            await _categoryCommandRepository.AddAsync(category);

            await _categoryCommandRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return new AddSubCategoryCommandResponse(new SuccessfulContentResponse<CategoryDto>(categoryDto, ResponseTitles.Success, ResponseMessages.SubCategoryAdded, System.Net.HttpStatusCode.OK));
        }
    }
}
