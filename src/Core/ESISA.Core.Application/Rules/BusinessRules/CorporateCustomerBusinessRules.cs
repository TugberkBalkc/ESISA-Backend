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
    public class CorporateCustomerBusinessRules : BusinessRulesBase
    {

        public CorporateCustomerBusinessRules() : base("Kurumsal Müşteri") { }

        public async Task CheckIfCorporateCustomerAccountActive(CorporateCustomer corporateCustomer)
        {
            if (corporateCustomer.IsActive == false)
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.CorporateCustomersAccountNotActive + " " + ResponseMessages.CommentNotCreated);
        }
    }
}
