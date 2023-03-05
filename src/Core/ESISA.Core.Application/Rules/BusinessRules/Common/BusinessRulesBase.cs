using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules.Common
{
    public abstract class BusinessRulesBase
    {
        public async Task NullCheck(object entity, String entityName)
        {
            if (entity is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{entityName} {ResponseMessages.NotFound}");
        }

        public async Task ExistsCheck(object entity, String entityName)
        {
            if (entity is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{entityName} {ResponseMessages.AlreadyExists}");
        }
    }
}
