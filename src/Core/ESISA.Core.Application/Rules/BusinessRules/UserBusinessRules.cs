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
    public class UserBusinessRules : BusinessRulesBase
    {
        public UserBusinessRules() : base("Kullanıcı") { }

        public async Task CheckIfUsersAccountActiveOnLogin(User user)
        {
            if (user.IsActive == false)
            {
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.NotLoggedIn + " " + ResponseMessages.BlockedAccount);
            }
        }

    }
}
