using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Identity
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByEmail(String userEmail);

        Task AddUser(User user);
        Task DeleteUserById(Guid userId);
        Task UpdateUser(User user);

        Task GetUserRolesByUserId(Guid userId);
    }
}
