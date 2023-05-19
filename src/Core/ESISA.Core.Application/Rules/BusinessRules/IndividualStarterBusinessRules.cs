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
    public class IndividualStarterBusinessRules : BusinessRulesBase
    {
        public IndividualStarterBusinessRules() :base("Bireysel Kullanıcı") { }

        public async Task CheckIfIndividualDealerAccountActiveOnCommenting(IndividualDealer individualDealer)
        {
            if(individualDealer.IsActive = false)
            {
                if (individualDealer.IsActive == false)
                    throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.IndividualDealersAccountNotActive + " " + ResponseMessages.CommentNotCreated);
            }
        }
    }


}
