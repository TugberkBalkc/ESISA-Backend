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
    public class AddressBusinessRules : BusinessRulesBase
    {
        public AddressBusinessRules() : base("Adres")
        {
        }

        public async Task OnAddresNotExists(Address address, Action action)
        {
            if (address is null)
            {
                action.Invoke();
            }
            else
            {
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
            }
        }
    }
}
