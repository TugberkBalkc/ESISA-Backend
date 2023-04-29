using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Rules.BusinessRules.Common;
using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class CorporateAdvertBusinessRules : BusinessRulesBase
    {
        public CorporateAdvertBusinessRules() : base("Kurumsal İlan")
        {
        }

        public async Task CheckIfCorporateAdvertAlreadyOutOfStock(CorporateAdvert corporateAdvert)
        {
            if(corporateAdvert.StockAmount <= 0)
            {
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.CorporateAdvertAlreadyOutOfStock);
            }
        }

        public async Task CheckIfCorporateAdvertAlreadyNotOutOfStock(CorporateAdvert corporateAdvert)
        {
            if (corporateAdvert.StockAmount >= 0)
            {
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.CorporateAdvertAlreadyNotOutOfStock);
            }
        }

    }
}
