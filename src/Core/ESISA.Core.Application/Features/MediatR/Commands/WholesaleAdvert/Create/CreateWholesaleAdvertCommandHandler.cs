using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Create
{
    public class CreateWholesaleAdvertCommandHandler : IRequestHandler<CreateWholesaleAdvertCommandRequest, CreateWholesaleAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IWholesaleAdvertCommandRepository _wholesaleAdvertCommandRepository;
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;

        private readonly IMapper _mapper;

        public CreateWholesaleAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, IWholesaleAdvertCommandRepository wholesaleAdvertCommandRepository, IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _wholesaleAdvertCommandRepository = wholesaleAdvertCommandRepository;
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateWholesaleAdvertCommandResponse> Handle(CreateWholesaleAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advertToCheck = await _advertQueryRepository.GetSingleAsync(e => e.Title == request.AdvertTitle && e.Description == request.AdvertDescription);

            await _wholesaleAdvertBusinessRules.ExistsCheck(advertToCheck);

            var advert = _mapper.Map<Advert>(request);

            await _advertCommandRepository.AddAsync(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var corporateAdvertToCheck = await _wholesaleAdvertQueryRepository.GetSingleAsync(e => e.AdvertId == advert.Id);

            await _wholesaleAdvertBusinessRules.ExistsCheck(corporateAdvertToCheck);

            var wholesaleAdvert = _mapper.Map<WholesaleAdvert>(request);
            this.SetWholesaleAdvert(wholesaleAdvert, advert.Id);

            await _wholesaleAdvertCommandRepository.AddAsync(wholesaleAdvert);
            await _wholesaleAdvertCommandRepository.SaveChangesAsync();

            var wholesaleAdvertDto = _mapper.Map<WholesaleAdvertDto>(request);
            this.SetWholesaleAdvertDto(wholesaleAdvertDto, advert, wholesaleAdvert.Id);

            return new CreateWholesaleAdvertCommandResponse(new SuccessfulContentResponse<WholesaleAdvertDto>(wholesaleAdvertDto, ResponseTitles.Success, ResponseMessages.WholesaleAdvertCreated, System.Net.HttpStatusCode.Created));
        }


        private void SetWholesaleAdvert(WholesaleAdvert wholesaleAdvert, Guid advertId)
        {
            wholesaleAdvert.AdvertId = advertId;
        }

        private void SetWholesaleAdvertDto(WholesaleAdvertDto wholesaleAdvertDto, Advert advert, Guid wholesaleAdvertId)
        {
            wholesaleAdvertDto.AdvertId = advert.Id;
            wholesaleAdvertDto.WholesaleAdvertId = wholesaleAdvertId;

            wholesaleAdvertDto.IsWholesaleAdvertActive = advert.IsActive;
        }
    }
}
