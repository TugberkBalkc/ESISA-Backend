﻿using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class CategoryBusinessRules 
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly String _entityName;

        public CategoryBusinessRules(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _entityName = "Kategori";
        }

        public virtual async Task NullCheck(object entity)
        {
            if (entity is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }

        public virtual async Task ExistsCheck(object entity)
        {
            if (entity is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }

        public async Task ExistsCheckByCategoryName(String categoryName)
        {
            var category = await _categoryQueryRepository.GetSingleAsync(c => c.Name == categoryName);

            if (category is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }

        public async Task NullCheckByCategroyId(Guid categoryId)
        {
            var category = await _categoryQueryRepository.GetByIdAsync(categoryId);

            if (category is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }

        public async Task CheckIfCategoryHasChildrenById(Guid categoryId, Func<Task> onHasChildren, Func<Task> onHasAnyChildren)
        {
            var parentCategory =await  _categoryQueryRepository.GetSingleAsync(predicate: e => e.Id == categoryId,
                                                                               trackingStatus: false,
                                                                               includes: e => e.Children);

            if (parentCategory.Children.Count == 0)
                await onHasAnyChildren.Invoke();
            else
                await onHasChildren.Invoke();
        }
    }
}
