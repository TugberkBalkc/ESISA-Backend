using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.CustomMapper
{
    public static class CustomMappingTool
    {
        public static IndividualAdvertDto MapToIndividualAdvertDto(Advert advert, IndividualAdvert individualAdvert)
        {
            var individualAdvertDto = new IndividualAdvertDto();

            individualAdvertDto.AdvertId = advert.Id;
            individualAdvertDto.IndividualAdvertId = individualAdvert.Id;

            individualAdvertDto.AdvertCreatedDate = advert.CreatedDate;
            individualAdvertDto.AdvertModifiedDate = advert.ModifiedDate;
            individualAdvertDto.AdvertIsActive = advert.IsActive;
            individualAdvertDto.IsIndividualAdvertActive = individualAdvert.IsActive;
            individualAdvertDto.AdvertIsDeleted = advert.IsDeleted;

            individualAdvertDto.AdvertTitle = advert.Title;
            individualAdvertDto.AdvertDescription = advert.Description;

            individualAdvertDto.IndividualAdvertIndividualDealerId = individualAdvert.IndividualDealerId;
            individualAdvertDto.IndividualAdvertProductId = individualAdvert.ProductId;

            individualAdvertDto.IndividualAdvertPrice = individualAdvert.Price;
            individualAdvertDto.IndividualAdvertBargain = individualAdvert.Bargain;
            individualAdvertDto.IndividualAdvertProductConditionType = individualAdvert.ProductConditionType;

            return individualAdvertDto;
        }

        public static CorporateAdvertDto MapToCorporateAdvertDto(Advert advert, CorporateAdvert corporateAdvert)
        {
            var corporateAdvertDto = new CorporateAdvertDto();

            corporateAdvertDto.AdvertId = advert.Id;
            corporateAdvertDto.CorporateAdvertId = corporateAdvert.Id;

            corporateAdvertDto.AdvertCreatedDate = advert.CreatedDate;
            corporateAdvertDto.AdvertModifiedDate = advert.ModifiedDate;
            corporateAdvertDto.AdvertIsActive = advert.IsActive;
            corporateAdvertDto.IsCorporateAdvertActive = corporateAdvert.IsActive;
            corporateAdvertDto.AdvertIsDeleted = advert.IsDeleted;

            corporateAdvertDto.AdvertTitle = advert.Title;
            corporateAdvertDto.AdvertDescription = advert.Description;

            corporateAdvertDto.CorporateAdvertCorporateDealerId = corporateAdvert.CorporateDealerId;
            corporateAdvertDto.CorporateAdvertProductId = corporateAdvert.ProductId;

            corporateAdvertDto.CorporateAdvertStockAmount = corporateAdvert.StockAmount;
            corporateAdvertDto.CorporateAdvertUnitPrice = corporateAdvert.UnitPrice;

            return corporateAdvertDto;
        }

        public static IQueryable<IndividualAdvertDto> MapIndividualAdvertDtosWithCustomMapper(List<Advert> adverts, List<IndividualAdvert> individualAdverts)
        {
            List<IndividualAdvertDto> individualAdvertDtos = new List<IndividualAdvertDto>();

            for (int i = 0; i < individualAdverts.Count; i++)
            {
                individualAdvertDtos.Add(CustomMappingTool.MapToIndividualAdvertDto(adverts[i], individualAdverts[i]));
            }

            return individualAdvertDtos.AsQueryable();
        }
    }
}
