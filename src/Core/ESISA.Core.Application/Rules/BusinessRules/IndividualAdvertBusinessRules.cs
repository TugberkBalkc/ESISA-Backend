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
    public class IndividualAdvertBusinessRules : BusinessRulesBase
    {
        public IndividualAdvertBusinessRules() : base("Bireysel İlan") { }

        public async Task CheckIfIndividualAdvertSold(IndividualAdvert individualAdvert)
        {
            if (!individualAdvert.IsActive)
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.RelatedAdvertSold);
        }
        public async Task CheckIfIndividualAdvertAlreadySold(IndividualAdvert individualAdvert)
        {
            if (!individualAdvert.IsActive)
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.RelatedAdvertAlreadyMarkedSold);
        }
    }
}
