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
    public class BrandBusinessRules : BusinessRulesBase
    {
        private readonly IBrandQueryRepository _brandQueryRepository;

        public BrandBusinessRules(IBrandQueryRepository brandQueryRepository)
        {
            _brandQueryRepository = brandQueryRepository;
        }

        public async Task ExistsCheckByBrandName(String brandName, String entityName)
        {
            var brand = await _brandQueryRepository.GetSingleAsync(p => p.Name == brandName);

            if (brand is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{entityName} {ResponseMessages.AlreadyExists}");
        }
    }
}
