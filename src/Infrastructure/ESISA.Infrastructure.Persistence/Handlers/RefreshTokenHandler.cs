using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Options.Authentication;
using ESISA.Core.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Handlers
{
    public class RefreshTokenHandler : IRefreshTokenHandler
    {
        private readonly IRefreshTokenCommandRepository _refreshTokenCommandRepository;
        private readonly IRefreshTokenQueryRepository _refreshTokenQueryRepository;

        private readonly IUserQueryRepository _userQueryRepository;

        private readonly RefreshTokenOptions _refreshTokenOptions;

        public RefreshTokenHandler(IRefreshTokenCommandRepository refreshTokenCommandRepository, IRefreshTokenQueryRepository refreshTokenQueryRepository, IUserQueryRepository userQueryRepository, IOptions<RefreshTokenOptions> options)
        {
            _refreshTokenCommandRepository = refreshTokenCommandRepository;
            _refreshTokenQueryRepository = refreshTokenQueryRepository;

            _userQueryRepository = userQueryRepository;

            _refreshTokenOptions = options.Value;
        }

        public async Task<RefreshToken> CreateRefreshTokenAsync(Guid userId)
        {
            var user = await _userQueryRepository.GetByIdAsync(userId);

            var refreshToken = new RefreshToken()
            {
                UserId = userId,
                Token = this.GenerateRefreshToken(),
                ExpirationDate = DateTime.Now.AddDays(_refreshTokenOptions.TokenLifeTimeInDays)
            };

            await _refreshTokenCommandRepository.AddAsync(refreshToken);

            await _refreshTokenCommandRepository.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<RefreshToken> UpdateRefreshTokenAsync(Guid userId)
        {
            var usersRefreshToken = await _refreshTokenQueryRepository.GetSingleAsync(e => e.UserId == userId);

            usersRefreshToken.ExpirationDate.AddDays(_refreshTokenOptions.TokenLifeTimeInDays);

            _refreshTokenCommandRepository.Update(usersRefreshToken);

            await _refreshTokenCommandRepository.SaveChangesAsync();

            return usersRefreshToken;
        }

        private String GenerateRefreshToken()
        {
            byte[] data = new byte[32];

            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(data);

            return Convert.ToBase64String(data);
        }
    }
}
