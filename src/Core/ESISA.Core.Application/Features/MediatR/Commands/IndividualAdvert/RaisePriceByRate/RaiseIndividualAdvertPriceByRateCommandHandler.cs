﻿using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate
{
    public class RaiseIndividualAdvertPriceByRateCommandHandler : IRequestHandler<RaiseIndividualAdvertPriceByRateCommandRequest, RaiseIndividualAdvertPriceByRateCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IIndividualAdvertCommandRepository _individualAdvertCommandRepository;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;

        public RaiseIndividualAdvertPriceByRateCommandHandler(IAdvertQueryRepository advertQueryRepository, IIndividualAdvertCommandRepository individualAdvertCommandRepository, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _individualAdvertCommandRepository = individualAdvertCommandRepository;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
        }

        public async Task<RaiseIndividualAdvertPriceByRateCommandResponse> Handle(RaiseIndividualAdvertPriceByRateCommandRequest request, CancellationToken cancellationToken)
        {
            var individualAdvert = await _individualAdvertQueryRepository.GetSingleAsync(e => e.Id == request.IndividualAdvertId);

            await _individualAdvertBusinessRules.NullCheck(individualAdvert);
            await _individualAdvertBusinessRules.CheckIfIndividualAdvertSold(individualAdvert);

            individualAdvert.Price = individualAdvert.Price + (individualAdvert.Price * Convert.ToInt32(request.RaiseRate) / 100);

            _individualAdvertCommandRepository.Update(individualAdvert);
            await _individualAdvertCommandRepository.SaveChangesAsync();

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == individualAdvert.AdvertId);

            var individualAdvertDto = CustomMappingTool.MapToIndividualAdvertDto(advert, individualAdvert);

            return new RaiseIndividualAdvertPriceByRateCommandResponse(new SuccessfulContentResponse<IndividualAdvertDto>(individualAdvertDto, ResponseTitles.Success, ResponseMessages.PriceRaised, System.Net.HttpStatusCode.OK));
        }
    }
}

