using AutoMapper;
using ESISA.Core.Application.Constants.EntityConstantValues;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Add
{
    public class AddMainCategoryCommandHandler : IRequestHandler<AddMainCategoryCommandRequest, AddMainCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IMapper _mapper;

        public AddMainCategoryCommandHandler
            (ICategoryCommandRepository categoryCommandRepository, CategoryBusinessRules categoryBusinessRules, 
             IMapper mapper)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryBusinessRules = categoryBusinessRules;
            _mapper = mapper;
        }

        public async Task<AddMainCategoryCommandResponse> Handle(AddMainCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.ExistsCheckByCategoryName(request.CategoryName, "Kategori");

            var category = _mapper.Map<Category>(request);

            this.SetParentIdToDefault(category);

            await _categoryCommandRepository.AddAsync(category);

            await _categoryCommandRepository.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return new AddMainCategoryCommandResponse(new SuccessfulContentResponse<CategoryDto>(categoryDto, ResponseTitles.Success, ResponseMessages.CategoryAdded, System.Net.HttpStatusCode.OK));
        }

        private void SetParentIdToDefault(Category category)
        {
            category.ParentId = Guid.Parse(DefaultIdValues.SuperCategoryId); 
        }
    }
}
