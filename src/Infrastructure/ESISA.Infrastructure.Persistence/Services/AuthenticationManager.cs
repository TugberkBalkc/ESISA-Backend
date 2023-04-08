using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authentication.Checkouts;
using ESISA.Core.Application.Dtos.Security.Authentication.Logins;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Utilities.Security.Hashing;
using ESISA.Core.Domain.Entities;

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

        private readonly ICorporateCustomerCommandRepository _corporateCustomerCommandRepository;
        private readonly ICorporateDealerCommandRepository _corporateDealerCommandRepository;

        private readonly IMapper _mapper;

        public AuthenticationManager
            (ITokenHandler tokenHandler, IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository,
             IDealerCommandRepository dealerCommandRepository, ICustomerCommandRepository customerCommandRepository,
             IIndividualDealerCommandRepository individualDealerCommandRepository, IIndividualCustomerCommandRepository individualCustomerCommandRepository, ICorporateCustomerCommandRepository corporateCustomerCommandRepository,
             ICorporateDealerCommandRepository corporateDealerCommandRepository, IMapper mapper)
        {
            _tokenHandler = tokenHandler;

            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;

            _dealerCommandRepository = dealerCommandRepository;
            _customerCommandRepository = customerCommandRepository;

            _individualDealerCommandRepository = individualDealerCommandRepository; ;
            _individualCustomerCommandRepository = individualCustomerCommandRepository;

            _corporateCustomerCommandRepository = corporateCustomerCommandRepository;

            _corporateDealerCommandRepository = corporateDealerCommandRepository;

            _mapper = mapper;
        }


        public Task<Token> LoginAsStarterAsync(StarterLoginDto starterLoginDto, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> LoginAsCorporateCustomerAsync(CorporateCustomerLoginDto customerLoginDto, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> LoginAsCorporateDealerAsync(CorporateDealerLoginDto corporateDealerLoginDto, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> LoginAsSupportAsync(SupportLoginDto supportLoginDto, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> LoginAsModeratorAsync(ModeratorLoginDto moderatorLoginDto, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GoogleLoginAsync(string idToken, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
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

        public Task<bool> VerifyResetTokenAsync(string resetToken, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IndividualStarterDto> RegisterAsIndividualStarterAsync(RegisterIndividualStarterDto registerIndividualStarterDto)
        {
            var user = _mapper.Map<User>(registerIndividualStarterDto);
            this.SetUserPassword(user, registerIndividualStarterDto.StarterPassword);
            await _userCommandRepository.AddAsync(user);
            await _userCommandRepository.SaveChangesAsync();

            var dealer = new Dealer() { UserId = user.Id };
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
            this.SetIndividualCustomerDto(individualStarterDto, individualCustomer);

            return individualStarterDto;
        }

        public async Task<CorporateCustomerDto> RegisterAsCorporateCustomerAsync(RegisterCorporateCustomerDto registerCorporateCustomerDto)
        {
            var user = _mapper.Map<User>(registerCorporateCustomerDto);
            this.SetUserPassword(user, registerCorporateCustomerDto.CorporateCustomerPassword);
            await _userCommandRepository.AddAsync(user);
            await _userCommandRepository.SaveChangesAsync();

            var customer = new Customer() { UserId = user.Id };
            await _customerCommandRepository.AddAsync(customer);
            await _customerCommandRepository.SaveChangesAsync();

            var corporateCustomer = _mapper.Map<CorporateCustomer>(registerCorporateCustomerDto);
            this.SetCorporateCustomer(corporateCustomer, customer.Id);
            await _corporateCustomerCommandRepository.AddAsync(corporateCustomer);
            await _corporateCustomerCommandRepository.SaveChangesAsync();

            var corporateCustomerDto = _mapper.Map<CorporateCustomerDto>(registerCorporateCustomerDto);
            this.SetCorporateCustomer(corporateCustomerDto, corporateCustomer);

            return corporateCustomerDto;
        }

        public async Task<CorporateDealerDto> RegisterAsCorporateDealerAsync(RegisterCorporateDealerDto registerCorporateDealerDto)
        {
            var user = _mapper.Map<User>(registerCorporateDealerDto);
            this.SetUserPassword(user, registerCorporateDealerDto.CorporateDealerPassword);
            await _userCommandRepository.AddAsync(user);
            await _userCommandRepository.SaveChangesAsync();

            var dealer = new Dealer() { UserId = user.Id };
            await _dealerCommandRepository.AddAsync(dealer);
            await _dealerCommandRepository.SaveChangesAsync();

            var corporateDealer = _mapper.Map<CorporateDealer>(registerCorporateDealerDto);
            this.SetCorporateDealer(corporateDealer, dealer.Id);
            await _corporateDealerCommandRepository.AddAsync(corporateDealer);
            await _corporateDealerCommandRepository.SaveChangesAsync();

            var corporateDealerDto = _mapper.Map<CorporateDealerDto>(registerCorporateDealerDto);
            this.SetCorporateDealer(corporateDealerDto, corporateDealer);
            return corporateDealerDto;
        }

        public Task<ModeratorDto> RegisterAsCorporateDealerAsync(RegisterModeratorDto registerModeratorDto)
        {
            throw new NotImplementedException();
        }

        public Task<SupportDto> RegisterAsCorporateDealerAsync(RegisterSupportDto registerSupportDto)
        {
            throw new NotImplementedException();
        }

        public Task StarterPasswordResetAsync(StarterPasswordResetDto starterPasswordResetDto)
        {
            throw new NotImplementedException();
        }

        public Task CorporateCustomerPasswordResetAsync(CorporateCustomerPasswordResetDto corporateCustomerPasswordResetDto)
        {
            throw new NotImplementedException();
        }

        public Task CorporateDealerPasswordResetAsync(CorporateDealerPasswordResetDto corporateDealerPasswordResetDto)
        {
            throw new NotImplementedException();
        }

        public Task SupportPasswordResetAsync(SupportPasswordResetDto supportPasswordResetDto)
        {
            throw new NotImplementedException();
        }

        public Task ModeratorPasswordResetAsync(ModeratorPasswordResetDto moderatorPasswordResetDto)
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
        private void SetIndividualCustomerDto(IndividualStarterDto individualStarterDto, IndividualCustomer individualCustomer)
        {
            individualStarterDto.StarterCreatedDate = individualCustomer.CreatedDate;
            individualStarterDto.StarterModifiedDate = individualCustomer.ModifiedDate;
            individualStarterDto.StarterIsActive = individualCustomer.IsActive;
            individualStarterDto.StarterIsDeleted = individualCustomer.IsDeleted;
        }

        private void SetCorporateCustomer(CorporateCustomer corporateCustomer, Guid customerId)
        {
            corporateCustomer.CustomerId = customerId;
        }
        private void SetCorporateCustomer(CorporateCustomerDto corporateCustomerDto, CorporateCustomer corporateCustomer)
        {
            corporateCustomerDto.CorporateCustomerCreatedDate = corporateCustomer.CreatedDate;
            corporateCustomerDto.CorporateCustomerModifiedDate = corporateCustomer.ModifiedDate;
            corporateCustomerDto.CorporateCustomerIsActive = corporateCustomer.IsActive;
            corporateCustomerDto.CorporateCustomerIsDeleted = corporateCustomer.IsDeleted;
            
        }

        private void SetCorporateDealer(CorporateDealer corporateDealer, Guid dealerId)
        {
            corporateDealer.DealerId = dealerId;
        }
        private void SetCorporateDealer(CorporateDealerDto corporateDealerDto, CorporateDealer corporateDealer)
        {
            corporateDealerDto.CorporateDealerCreatedDate = corporateDealer.CreatedDate;
            corporateDealerDto.CorporateDealerModifiedDate = corporateDealer.ModifiedDate;
            corporateDealerDto.CorporateDealerIsActive = corporateDealer.IsActive;
            corporateDealerDto.CorporateDealerIsDeleted = corporateDealer.IsDeleted;
        }

    }
}
