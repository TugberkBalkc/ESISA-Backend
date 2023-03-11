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
    public class ProductBusinessRules
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly String _entityName;
        public ProductBusinessRules(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
            _entityName = "Ürün";
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

        public async Task ExistsCheckByProductName(String productName)
        {
            var product = await _productQueryRepository.GetSingleAsync(p=>p.Name == productName);
           
            if (product is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }

        public async Task NullCheckByProductId(Guid productId)
        {
            var product = await _productQueryRepository.GetByIdAsync(productId);

            if (product is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }
    }
}
