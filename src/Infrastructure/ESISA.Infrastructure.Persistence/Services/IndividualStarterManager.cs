using ESISA.Core.Application.Interfaces.Services.Identity;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Services
{
    public class IndividualStarterManager : IIndividualStarterService
    {
        public Task DeleteIndividualStarterByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetIndividualStarterByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetIndividualStarterById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIndividualStarter(User user, IndividualCustomer individualCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
