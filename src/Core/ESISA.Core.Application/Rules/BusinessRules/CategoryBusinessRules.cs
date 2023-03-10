using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules.Common;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class CategoryBusinessRules : BusinessRulesBase
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public CategoryBusinessRules(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task ExistsCheckByCategoryName(String categoryName, String entityName)
        {
            var category = await _categoryQueryRepository.GetSingleAsync(c => c.Name == categoryName);

            if (category is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{entityName} {ResponseMessages.AlreadyExists}");
        }
    }
}
