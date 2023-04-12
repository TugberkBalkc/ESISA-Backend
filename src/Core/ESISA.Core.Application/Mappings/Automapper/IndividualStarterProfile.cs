using AutoMapper;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.UpdateIndividualStarter;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class IndividualStarterProfile : Profile
    {
        public IndividualStarterProfile()
        {
            this.CreateMap<RegisterIndividualStarterDto, IndividualStarterDto>();

            this.CreateMap<RegisterIndividualStarterDto, User>()
                .ForMember(e => e.UserName, e => e.MapFrom(e => e.StarterUserName))
                .ForMember(e => e.Email, e => e.MapFrom(e => e.StarterEmail))
                .ForMember(e => e.ContactNumber, e => e.MapFrom(e => e.StarterContactNumber));

            this.CreateMap<RegisterIndividualStarterDto, IndividualCustomer>()
                .ForMember(e => e.FirstName, e => e.MapFrom(e => e.StarterFirstName))
                .ForMember(e => e.LastName, e => e.MapFrom(e => e.StarterLastName))
                .ForMember(e => e.NationalIdentity, e => e.MapFrom(e => e.StarterNationalIdentity))
                .ForMember(e => e.DateOfBirth, e => e.MapFrom(e => e.StarterDateOfBirth));
        }
    }
}
