using AutoMapper;
using ESISA.Core.Application.Constants.Response;
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
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories;

namespace ESISA.Infrastructure.Persistence.Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ITokenHandler _tokenHandler;

        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;       

        private readonly IDealerCommandRepository _dealerCommandRepository;
        private readonly IDealerQueryRepository _dealerQueryRepository;

        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        private readonly IIndividualDealerCommandRepository _individualDealerCommandRepository;
        private readonly IIndividualCustomerCommandRepository _individualCustomerCommandRepository;
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;

        private readonly ICorporateCustomerCommandRepository _corporateCustomerCommandRepository;
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;

        private readonly ICorporateDealerCommandRepository _corporateDealerCommandRepository;
        private readonly ICorporateDealerQueryRepository _corporateDealerQueryRepository;

        private readonly IMapper _mapper;

        public AuthenticationManager
            (ITokenHandler tokenHandler, IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository,
             IDealerCommandRepository dealerCommandRepository, ICustomerCommandRepository customerCommandRepository,
             IIndividualDealerCommandRepository individualDealerCommandRepository, IIndividualCustomerCommandRepository individualCustomerCommandRepository, ICorporateCustomerCommandRepository corporateCustomerCommandRepository, ICorporateCustomerQueryRepository corporateCustomerQueryRepository,
             ICorporateDealerCommandRepository corporateDealerCommandRepository, ICorporateDealerQueryRepository corporateDealerQueryRepository, IMapper mapper,ICustomerQueryRepository customerQueryRepository, IIndividualCustomerQueryRepository individualCustomerQueryRepository, IDealerQueryRepository dealerQueryRepository)
        {
            _tokenHandler = tokenHandler;

            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;


            _dealerCommandRepository = dealerCommandRepository;
            _dealerQueryRepository = dealerQueryRepository;

            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;

            _individualDealerCommandRepository = individualDealerCommandRepository; ;
            _individualCustomerCommandRepository = individualCustomerCommandRepository;
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _corporateCustomerCommandRepository = corporateCustomerCommandRepository;
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;

            _corporateDealerCommandRepository = corporateDealerCommandRepository;
            _corporateDealerQueryRepository = corporateDealerQueryRepository;

            _mapper = mapper;
        }


        public async Task<UserDto> GetUserByEmailAsync(String userEmail)
        {
            var user = await _userQueryRepository.GetSingleAsync(e => e.Email == userEmail);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public Task<Token> GoogleLoginAsync(string idToken, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }

        public Task<Token> FacebookLoginAsync(string authToken, int tokenLifeTimeInSeconds)
        {
            throw new NotImplementedException();
        }


        public async Task<Token> LoginAsStarterAsync(StarterLoginDto starterLoginDto)
        {
            var user = await _userQueryRepository.GetSingleAsync(e => e.Email == starterLoginDto.StarterEmail);

            this.VerifyUserPassword(starterLoginDto.StarterPassword, user.PasswordHash, user.PasswordSalt);

            var usersRoleNames = _userQueryRepository.GetRolesByUserId(user.Id).Select(e => e.Name).ToArray();

            var customer = await _customerQueryRepository.GetSingleAsync(e => e.UserId == user.Id);

            var individualCustomer = await _individualCustomerQueryRepository.GetSingleAsync(e => e.CustomerId == customer.Id);

            var token = _tokenHandler.CreateTokenForIndividualStarter(user.Id, individualCustomer.FirstName, individualCustomer.LastName, user.Email, usersRoleNames);

            return token;
        }

        public async Task<Token> LoginAsCorporateCustomerAsync(CorporateCustomerLoginDto corporateCustomerLoginDto)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetSingleAsync(e => e.TaxIdentityNumber == corporateCustomerLoginDto.CorporateCustomerTaxIdentityNumber);

            var customer = await _customerQueryRepository.GetByIdAsync(corporateCustomer.CustomerId);
            var user = await _userQueryRepository.GetByIdAsync(customer.UserId);

            this.VerifyUserPassword(corporateCustomerLoginDto.CorporateCustomerPassword, user.PasswordHash, user.PasswordSalt);

            var usersRoleNames = _userQueryRepository.GetRolesByUserId(user.Id).Select(e => e.Name).ToArray();

            var token = _tokenHandler.CreateTokenForCorporateUser(user.Id, corporateCustomer.TaxIdentityNumber, user.Email, usersRoleNames);

            return token;
        }

        public async Task<Token> LoginAsCorporateDealerAsync(CorporateDealerLoginDto corporateDealerLoginDto)
        {
            var corporateDealer = await _corporateDealerQueryRepository.GetSingleAsync(e => e.TaxIdentityNumber == corporateDealerLoginDto.CorporateDealerTaxIdentityNumber);

            var dealer = await _dealerQueryRepository.GetByIdAsync(corporateDealer.DealerId);
            var user = await _userQueryRepository.GetByIdAsync(dealer.UserId);

            this.VerifyUserPassword(corporateDealerLoginDto.CorporateDealerPassword, user.PasswordHash, user.PasswordSalt);

            var usersRoleNames = _userQueryRepository.GetRolesByUserId(user.Id).Select(e => e.Name).ToArray();

            var token = _tokenHandler.CreateTokenForCorporateUser(user.Id, corporateDealer.TaxIdentityNumber, user.Email, usersRoleNames);

            return token;
        }

        public Task<Token> LoginAsModeratorAsync(ModeratorLoginDto moderatorLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<Token> LoginAsSupportAsync(SupportLoginDto supportLoginDto)
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
            this.SetIndividualStarterDto(individualStarterDto, user, customer.Id, dealer.Id, individualCustomer.Id, individualDealer.Id);

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
            this.SetCorporateCustomerDto(corporateCustomerDto, user, customer.Id, corporateCustomer.Id);

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
            this.SetCorporateDealerDto(corporateDealerDto, user, dealer.Id, corporateDealer.Id, corporateDealer.AddressId, corporateDealer.SalesCategoryId);
            return corporateDealerDto;
        }

        public Task<ModeratorDto> RegisterAsModeratorAsync(RegisterModeratorDto registerModeratorDto)
        {
            throw new NotImplementedException();
        }

        public Task<SupportDto> RegisterAsSupportAsync(RegisterSupportDto registerSupportDto)
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

        private void VerifyUserPassword(String userPassword, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            var compareResult = HashingHelper.VerifyHashes(userPassword, userPasswordHash, userPasswordSalt);

            if (!compareResult)
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.UserPasswordOrEmailNotCorrect);
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
        private void SetIndividualStarterDto(IndividualStarterDto individualStarterDto, User user, Guid customerId, Guid dealerId, Guid individualCustomerId, Guid individualDealerId)
        {
            individualStarterDto.StarterUserCreatedDate = user.CreatedDate;
            individualStarterDto.StarterUserModifiedDate = user.ModifiedDate;
            individualStarterDto.StarterUserIsDeleted = user.IsDeleted;
            individualStarterDto.StarterUserIsActive = user.IsActive;

            individualStarterDto.StarterUserId = user.Id;
            individualStarterDto.StarterCustomerId = customerId;
            individualStarterDto.StarterDealerId = dealerId;

            individualStarterDto.StarterStatus = user.Status;
            individualStarterDto.StarterIndividualCustomerId = individualCustomerId;
            individualStarterDto.StarterIndividualDealerId = individualDealerId;
            individualStarterDto.StarterStatus = user.Status;
        }


        private void SetCorporateCustomer(CorporateCustomer corporateCustomer, Guid customerId)
        {
            corporateCustomer.CustomerId = customerId;
        }
        private void SetCorporateCustomerDto(CorporateCustomerDto corporateCustomerDto, User user, Guid customerId, Guid corporateCustomerId)
        {
            corporateCustomerDto.CorporateCustomerUserCreatedDate = user.CreatedDate;
            corporateCustomerDto.CorporateCustomerUserModifiedDate = user.ModifiedDate;
            corporateCustomerDto.CorporateCustomerUserIsActive = user.IsActive;
            corporateCustomerDto.CorporateCustomerUserIsDeleted = user.IsDeleted;
            corporateCustomerDto.CorporateCustomerUserId = user.Id;
            corporateCustomerDto.CorporateCustomerCustomerId = customerId;
            corporateCustomerDto.CorporateCustomerId = corporateCustomerId;
        }


        private void SetCorporateDealer(CorporateDealer corporateDealer, Guid dealerId)
        {
            corporateDealer.DealerId = dealerId;
        }
        private void SetCorporateDealerDto(CorporateDealerDto corporateDealerDto, User user, Guid dealerId, Guid corporateDealerId, Guid addressId, Guid categoryId)
        {
            corporateDealerDto.CorporateDealerUserCreatedDate = user.CreatedDate;
            corporateDealerDto.CorporateDealerUserModifiedDate = user.ModifiedDate;
            corporateDealerDto.CorporateDealerUserIsActive = user.IsActive;
            corporateDealerDto.CorporateDealerUserIsDeleted = user.IsDeleted;
            corporateDealerDto.CorporateDealerUserId = user.Id;
            corporateDealerDto.CorporateDealerDealerId = dealerId;
            corporateDealerDto.CorporateDealerId = corporateDealerId;

            corporateDealerDto.CorporateDealerAddressId = addressId;
            corporateDealerDto.CorporateDealerSalesCategoryId = categoryId;
        }
    }
}
