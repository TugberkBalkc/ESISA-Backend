using AutoMapper;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.Common;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.UpdateIndividualStarter
{
    public class UpdateIndividualStarterCommandRequest : IRequest<UpdateIndividualStarterCommandResponse>
    {
        public String? IndividualStarterEmail { get; set; }
        public String? IndividualStarterUserName { get; set; }
        public String? IndividualStarterContactNumber { get; set; }

        public String? IndividualStarterFirstName { get; set; }
        public String? IndividualStarterLastName { get; set; }
        public String? IndividualStarterNationalIdentity { get; set; }
        public DateTime? IndividualStarterDateOfBirth { get; set; }

        public UpdateIndividualStarterCommandRequest()
        {

        }

        public UpdateIndividualStarterCommandRequest(string? individualStarterEmail, string? individualStarterUserName, string? individualStarterContactNumber, string? individualStarterFirstName, string? individualStarterLastName, string? individualStarterNationalIdentity, DateTime? individualStarterDateOfBirth)
        {
            IndividualStarterEmail = individualStarterEmail;
            IndividualStarterUserName = individualStarterUserName;
            IndividualStarterContactNumber = individualStarterContactNumber;
            IndividualStarterFirstName = individualStarterFirstName;
            IndividualStarterLastName = individualStarterLastName;
            IndividualStarterNationalIdentity = individualStarterNationalIdentity;
            IndividualStarterDateOfBirth = individualStarterDateOfBirth;
        }
    }
    public class UpdateIndividualStarterCommandResponse : CommandResponseBase<IndividualStarterDto>
    {
        public UpdateIndividualStarterCommandResponse(IContentResponse<IndividualStarterDto> response) : base(response)
        {
        }
    }
    public class UpdateIndividualStarterCommandHandler : IRequestHandler<UpdateIndividualStarterCommandRequest, UpdateIndividualStarterCommandResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        private readonly ICustomerQueryRepository _customerQueryRepository;

        private readonly IIndividualCustomerCommandRepository _individualCustomerCommandRepository;
        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;

        private readonly UserBusinessRules _userBusinessRules;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;

        private readonly IMapper _mapper;

        public UpdateIndividualStarterCommandHandler(IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository, IIndividualCustomerCommandRepository individualCustomerCommandRepository, ICustomerQueryRepository customerQueryRepository, IIndividualCustomerQueryRepository individualCustomerQueryRepository, UserBusinessRules userBusinessRules, CustomerBusinessRules customerBusinessRules, IndividualStarterBusinessRules individualStarterBusinessRules, IMapper mapper)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;

            _individualCustomerCommandRepository = individualCustomerCommandRepository;
            _individualCustomerQueryRepository = individualCustomerQueryRepository;

            _customerQueryRepository = customerQueryRepository;

            _userBusinessRules = userBusinessRules;
            _customerBusinessRules = customerBusinessRules;
            _individualStarterBusinessRules = individualStarterBusinessRules;

            _mapper = mapper;
        }

        public async Task<UpdateIndividualStarterCommandResponse> Handle(UpdateIndividualStarterCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetSingleAsync(e => e.Email == request.IndividualStarterEmail);

            await _userBusinessRules.NullCheck(user);

            var updatedUser = _mapper.Map(request, user);

            _userCommandRepository.Update(user);

            await _userCommandRepository.SaveChangesAsync();


            var customer = await _customerQueryRepository.GetSingleAsync(e => e.UserId == user.Id);

            await _customerBusinessRules.NullCheck(customer);

            var individualCustomer = await _individualCustomerQueryRepository.GetSingleAsync(e => e.CustomerId == customer.Id);

            await _individualStarterBusinessRules.NullCheck(individualCustomer);

            var updatedIndividualCustomer = _mapper.Map(request, individualCustomer);

            _individualCustomerCommandRepository.Update(individualCustomer);

            await _individualCustomerCommandRepository.SaveChangesAsync();

            return new UpdateIndividualStarterCommandResponse(new SuccessfulContentResponse<IndividualStarterDto>(null));
        }

        //private IndividualStarterDto SetIndividualStarter(User user, Customer customer, Dealer dealer, IndividualDealer , individualDealer, IndividualCustomer individualCustomer)
        //{
        //    return new IndividualStarterDto()
        //    {
        //        StarterId
        //    }
        //}
    }
}
