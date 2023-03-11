using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class CategoryDemandBusinessRules
    {
        private readonly ICategoryDemandQueryRepository _categoryDemandQueryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly String _entityName;

        public CategoryDemandBusinessRules(ICategoryDemandQueryRepository categoryDemandQueryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDemandQueryRepository = categoryDemandQueryRepository;
            _categoryBusinessRules = categoryBusinessRules;

            _entityName = "Kategori Talebi";
        }

        public async Task CheckIfDemandedCategoryExistsByCategoryName(String categoryName)
        {
            await _categoryBusinessRules.ExistsCheckByCategoryName(categoryName);
        }

        public async Task CheckIfCategoryDemandExists(String categoryName)
        {
            var categoryDemand = await _categoryDemandQueryRepository.GetSingleAsync(e => e.CategoryName.Trim().ToLower() == categoryName.Trim().ToLower());

            if (categoryDemand is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}. \n ({ResponseMessages.OtherUsersSentDemand})");
        }

        public async Task CheckIfCategoryDemandNull(Guid categoryDemandId)
        {
            var categoryDemand = await _categoryDemandQueryRepository.GetByIdAsync(categoryDemandId);

            if (categoryDemand is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}.");
        }
    }
}
