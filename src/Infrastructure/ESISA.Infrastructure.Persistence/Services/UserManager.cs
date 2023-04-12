using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Identity;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Services
{
    internal class UserManager : IUserService
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public UserManager(IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task AddUser(User user)
        {
            await _userCommandRepository.AddAsync(user);
            await _userCommandRepository.SaveChangesAsync();
        }

        public async Task DeleteUserById(Guid userId)
        {
            await _userCommandRepository.DeleteAsync(userId);
            await _userCommandRepository.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _userQueryRepository.GetSingleAsync(e => e.Email == userEmail);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userQueryRepository.GetByIdAsync(userId);
        }

        public async Task UpdateUser(User user)
        {
             _userCommandRepository.Update(user);
        }
    }
}
