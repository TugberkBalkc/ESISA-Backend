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
    public class BrandBusinessRules
    {
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly String _entityName;

        public BrandBusinessRules(IBrandQueryRepository brandQueryRepository)
        {
            _brandQueryRepository = brandQueryRepository;
            _entityName = "Marka";
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

        public async Task ExistsCheckByBrandName(String brandName)
        {
            var brand = await _brandQueryRepository.GetSingleAsync(p => p.Name == brandName);

            if (brand is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }

        public async Task NullCheckByBrandId(Guid brandId)
        {
            var brand = await _brandQueryRepository.GetByIdAsync(brandId);

            if (brand is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }
    }
}
