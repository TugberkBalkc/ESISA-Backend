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
    public class ProductBusinessRules : BusinessRulesBase
    {
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductBusinessRules(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        public async Task ExistsCheckByProductName(String productName, String entityName)
        {
            var product = await _productQueryRepository.GetSingleAsync(p=>p.Name == productName);
           
            if (product is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{entityName} {ResponseMessages.AlreadyExists}");
        }
    }
}
