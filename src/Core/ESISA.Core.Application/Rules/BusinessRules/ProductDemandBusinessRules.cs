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
    public class ProductDemandBusinessRules
    {
        private readonly IProductDemandQueryRepository _productDemandQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly String _entityName;

        public ProductDemandBusinessRules(IProductDemandQueryRepository productDemandQueryRepository, ProductBusinessRules productBusinessRules)
        {
            _productDemandQueryRepository = productDemandQueryRepository;
            _productBusinessRules = productBusinessRules;
            _entityName = "Ürün Talebi";
        }

        public async Task CheckIfDemandedProductExistsByProductName(String productName)
        {
            await _productBusinessRules.ExistsCheckByProductName(productName);
        }

        public async Task CheckIfProductDemandExists(String productName)
        {
            var productDemand = await _productDemandQueryRepository.GetSingleAsync(e => e.ProductName.Trim().ToLower() == productName.Trim().ToLower());

            if (productDemand is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}. \n ({ResponseMessages.OtherUsersSentDemand})");
        }

        public async Task CheckIfProductDemandNull(Guid productDemandId)
        {
            var productDemand = await _productDemandQueryRepository.GetByIdAsync(productDemandId);

            if (productDemand is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}.");
        }
    }
}
