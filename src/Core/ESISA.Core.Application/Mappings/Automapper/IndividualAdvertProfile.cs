using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.AddAddress;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class IndividualAdvertProfile : Profile
    {
        public IndividualAdvertProfile()
        {
            this.CreateMap<CreateIndividualAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<CreateIndividualAdvertCommandRequest, IndividualAdvert>()
                .ForMember(e => e.IndividualDealerId, e => e.MapFrom(e => e.IndividualAdvertIndividualDealerId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.IndividualAdvertProductId))
                .ForMember(e => e.Price, e => e.MapFrom(e => e.IndividualAdvertPrice))
                .ForMember(e => e.Bargain, e => e.MapFrom(e => e.IndividualAdvertBargain))
                .ForMember(e => e.ProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType));

            this.CreateMap<CreateIndividualAdvertCommandRequest, IndividualAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.IndividualAdvertIndividualDealerId, e => e.MapFrom(e => e.IndividualAdvertIndividualDealerId))
                .ForMember(e => e.IndividualAdvertProductId, e => e.MapFrom(e => e.IndividualAdvertProductId))
                .ForMember(e => e.IndividualAdvertProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType));

            this.CreateMap<UpdateIndividualAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<UpdateIndividualAdvertCommandRequest, IndividualAdvert>()
            .ForMember(e => e.Price, e => e.MapFrom(e => e.IndividualAdvertPrice))
            .ForMember(e => e.Bargain, e => e.MapFrom(e => e.IndividualAdvertBargain))
            .ForMember(e => e.ProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType));

            this.CreateMap<UpdateIndividualAdvertCommandRequest, IndividualAdvertDto>()
              .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
              .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
              .ForMember(e => e.IndividualAdvertProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType))
              .ForMember(e => e.IndividualAdvertPrice, e => e.MapFrom(e => e.IndividualAdvertPrice))
              .ForMember(e => e.IndividualAdvertBargain, e => e.MapFrom(e => e.IndividualAdvertBargain));

            this.CreateMap<IndividualAdvert, IndividualAdvertDto>()
            .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
            .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
            .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
            .ForMember(e => e.IndividualAdvertId, e => e.MapFrom(e => e.Id))
            .ForMember(e => e.IsIndividualAdvertActive, e => e.MapFrom(e => e.IsActive))
            .ForMember(e => e.IndividualAdvertPrice, e => e.MapFrom(e => e.Price))
            .ForMember(e => e.IndividualAdvertBargain, e => e.MapFrom(e => e.Bargain))
            .ForMember(e => e.IndividualAdvertIndividualDealerId, e => e.MapFrom(e => e.IndividualDealerId))
            .ForMember(e => e.IndividualAdvertProductId, e => e.MapFrom(e => e.ProductId))
            .ForMember(e => e.IndividualAdvertProductConditionType, e => e.MapFrom(e => e.ProductConditionType));

            this.CreateMap<AddAddressToIndividualCustomerCommandRequest, Address>()
                .ForMember(e => e.CountryId, e => e.MapFrom(e => e.AddressCountryId))
                .ForMember(e => e.CityId, e => e.MapFrom(e => e.AddressCityId))
                .ForMember(e => e.DistrictId, e => e.MapFrom(e => e.AddressDistrictId))
                .ForMember(e => e.Details, e => e.MapFrom(e => e.AddressDetails))
                .ForMember(e => e.PostalCode, e => e.MapFrom(e => e.AddressPostalCode));

            //this.CreateMap<IndividualAdvert, IndividualAdvertDetailsDto>()
            //   .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
            //   .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
            //   .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
            //   .ForMember(e=>e.IndividualAdvertId, e=>e.MapFrom(e=>e.Id))
            //   .ForMember(e => e.IsIndividualAdvertActive, e => e.MapFrom(e => e.IsActive))
            //   .ForMember(e => e.IndividualAdvertPrice, e => e.MapFrom(e => e.Price))
            //   .ForMember(e => e.IndividualAdvertBargain, e => e.MapFrom(e => e.Bargain))
            //   .ForMember(e => e.IndividualAdvertIndividualDealerId, e => e.MapFrom(e => e.IndividualDealerId))
            //   .ForMember(e => e.IndividualAdvertIndividualDealerFirstName, e => e.MapFrom(e => e.IndividualDealer.Dealer.User.Customer.IndividualCustomer.FirstName))
            //   .ForMember(e => e.IndividualAdvertIndividualDealerLastName, e => e.MapFrom(e => e.IndividualDealer.Dealer.User.Customer.IndividualCustomer.LastName))
            //   .ForMember(e => e.IndividualAdvertProductId, e => e.MapFrom(e => e.ProductId))
            //   .ForMember(e => e.IndividualAdvertProductName, e => e.MapFrom(e => e.Product.Name))
            //   .ForMember(e => e.IndividualAdvertProductBrandId, e => e.MapFrom(e => e.Product.BrandId))
            //   .ForMember(e => e.IndividualAdvertProductBrandName, e => e.MapFrom(e => e.Product.Brand.Name))
            //   .ForMember(e => e.IndividualAdvertProductCategoryId, e => e.MapFrom(e => e.Product.CategoryId))
            //   .ForMember(e => e.IndividualAdvertProductCategoryName, e => e.MapFrom(e => e.Product.Category.Name))
            //   .ForMember(e => e.IndividualAdvertProductConditionType, e => e.MapFrom(e => e.ProductConditionType))
            //   .ForMember(e => e.AdvertsFavoriteCount, e => e.MapFrom(e => e.IndividualCustomerIndividualAdvertFavorites.Count));
        }
    }
}
