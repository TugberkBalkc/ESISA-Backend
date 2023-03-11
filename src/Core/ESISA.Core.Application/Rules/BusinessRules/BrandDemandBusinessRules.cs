using ESISA.Core.Application.Constants.Response;
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
    public class BrandDemandBusinessRules
    {
        private readonly IBrandDemandQueryRepository _brandDemandQueryRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly String _entityName;

        public BrandDemandBusinessRules(IBrandDemandQueryRepository brandDemandQueryRepository, BrandBusinessRules brandBusinessRules)
        {
            _brandDemandQueryRepository = brandDemandQueryRepository;
            _brandBusinessRules = brandBusinessRules;

            _entityName = "Marka Talebi";
        }

        public async Task CheckIfDemandedBrandExistsByBrandName(String brandName)
        {
            await _brandBusinessRules.ExistsCheckByBrandName(brandName);
        }

        public async Task CheckIfBrandDemandExists(String brandName)
        {
            var brandDemand = await _brandDemandQueryRepository.GetSingleAsync(e => e.BrandName.Trim().ToLower() == brandName.Trim().ToLower());

            if(brandDemand is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}. \n ({ResponseMessages.OtherUsersSentDemand})");
        }

        public async Task CheckIfBrandDemandNull(Guid brandDemandId)
        {
            var brandDemand = await _brandDemandQueryRepository.GetByIdAsync(brandDemandId);

            if (brandDemand is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }
    }
}
