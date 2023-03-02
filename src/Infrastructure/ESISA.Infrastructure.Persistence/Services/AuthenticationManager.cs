using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ITokenHandler _tokenHandler;

        private readonly IUserCommandRepository _userCommandRepository;

        private readonly IMapper _mapper;

        public AuthenticationManager(ITokenHandler tokenHandler, IUserCommandRepository userCommandRepository, IMapper mapper)
        {
            _tokenHandler = tokenHandler;
            _userCommandRepository = userCommandRepository;

            _mapper = mapper;
        }

        public Task<Token> FacebookLoginAsync(string authToken, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GoogleLoginAsync(string idToken, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> LoginAsync(UserLoginDto userLoginDto, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<CorporateCustomerDto> RegisterAsCorporateCustomerAsync(RegisterCorporateCustomerDto registerCorporateCustomerDto)
        {
            throw new NotImplementedException();
        }

        public Task<CorporateDealerDto> RegisterAsCorporateDealerAsync(RegisterCorporateDealerDto registerCorporateDealerDto)
        {
            throw new NotImplementedException();
        }

        public Task<ModeratorDto> RegisterAsCorporateDealerAsync(RegisterModeratorDto registerModeratorDto)
        {
            throw new NotImplementedException();
        }

        public Task<SupportDto> RegisterAsCorporateDealerAsync(RegisterSupportDto registerSupportDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IndividualStarterDto> RegisterAsIndividualStarterAsync(RegisterIndividualStarterDto registerIndividualStarterDto)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(UserResetPasswordDto userResetPasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
