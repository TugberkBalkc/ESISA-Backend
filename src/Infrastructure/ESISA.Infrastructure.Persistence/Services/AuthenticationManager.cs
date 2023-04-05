using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.IndividualStarter;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Utilities.Security.Hashing;
using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using Microsoft.Identity.Client;
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
        private readonly IUserQueryRepository _userQueryRepository;       

        private readonly IDealerCommandRepository _dealerCommandRepository;
        private readonly ICustomerCommandRepository _customerCommandRepository;
        
        private readonly IIndividualDealerCommandRepository _individualDealerCommandRepository;
        private readonly IIndividualCustomerCommandRepository _individualCustomerCommandRepository;

        private readonly IMapper _mapper;

        public AuthenticationManager
            (ITokenHandler tokenHandler, IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository,
             IDealerCommandRepository dealerCommandRepository, ICustomerCommandRepository customerCommandRepository,
             IIndividualDealerCommandRepository individualDealerCommandRepository, IIndividualCustomerCommandRepository individualCustomerCommandRepository,
             IMapper mapper)
        {
            _tokenHandler = tokenHandler;

            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;

            _dealerCommandRepository = dealerCommandRepository;
            _customerCommandRepository = customerCommandRepository;

            _individualDealerCommandRepository = individualDealerCommandRepository; ;
            _individualCustomerCommandRepository = individualCustomerCommandRepository;

            _mapper = mapper;
        }

        public Task<Token> FacebookLoginAsync(string authToken, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByEmailAsync(String userEmail)
        {
            var user = await _userQueryRepository.GetSingleAsync(e=>e.Email == userEmail);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
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
            var user = _mapper.Map<User>(registerIndividualStarterDto);
            this.SetUserPassword(user, registerIndividualStarterDto.StarterPassword);
            await _userCommandRepository.AddAsync(user);
            await _userCommandRepository.SaveChangesAsync();

            var dealer = new Dealer(){ UserId = user.Id };
            await _dealerCommandRepository.AddAsync(dealer);
            await _dealerCommandRepository.SaveChangesAsync();

            var customer = new Customer() { UserId = user.Id };
            await _customerCommandRepository.AddAsync(customer);
            await _customerCommandRepository.SaveChangesAsync();

            var individualDealer = new IndividualDealer() { DealerId = dealer.Id };
            await _individualDealerCommandRepository.AddAsync(individualDealer);
            await _individualDealerCommandRepository.SaveChangesAsync();

            var individualCustomer = _mapper.Map<IndividualCustomer>(registerIndividualStarterDto);
            this.SetIndividualCustomer(individualCustomer, customer.Id);
            await _individualCustomerCommandRepository.AddAsync(individualCustomer);
            await _individualCustomerCommandRepository.SaveChangesAsync();

            var individualStarterDto = _mapper.Map<IndividualStarterDto>(registerIndividualStarterDto);
            return individualStarterDto;
        }

        public Task ResetPasswordAsync(UserResetPasswordDto userResetPasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, Guid userId)
        {
            throw new NotImplementedException();
        }

        private void SetUserPassword(User user, String password)
        {
            var hashResult = HashingHelper.ComputeHashByKeyValue(password);

            user.PasswordHash = hashResult.Hash;
            user.PasswordSalt = hashResult.Salt;
        }

        private void SetIndividualCustomer(IndividualCustomer individualCustomer, Guid customerId)
        {
            individualCustomer.CustomerId = customerId;
        }
    }
}
