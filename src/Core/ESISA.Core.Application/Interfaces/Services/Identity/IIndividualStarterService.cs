using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Identity
{
    public interface IIndividualStarterService
    {
        Task<User> GetIndividualStarterById(Guid userId);
        Task<User> GetIndividualStarterByEmail(String userEmail);

        Task DeleteIndividualStarterByUserId(Guid userId);
        Task UpdateIndividualStarter(User user, IndividualCustomer individualCustomer);
    }
}
