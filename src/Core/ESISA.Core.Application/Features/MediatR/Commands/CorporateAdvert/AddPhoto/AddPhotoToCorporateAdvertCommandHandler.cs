using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.AddPhoto
{
    public class AddPhotoToCorporateAdvertCommandHandler : IRequestHandler<AddPhotoToCorporateAdvertCommandRequest, AddPhotoToCorporateAdvertCommandResponse>
    {
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;

        private readonly IAdvertPhotoPathCommandRepository _photoPathCommandRepository;
        private readonly IAdvertPhotoPathQueryRepository _photoPathQueryRepository;
        private readonly PhotoPathBusinessRules _photoPathBusinessRules;

        private readonly IMapper _mapper;
        public AddPhotoToCorporateAdvertCommandHandler(ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IAdvertPhotoPathCommandRepository photoPathCommandRepository, IAdvertPhotoPathQueryRepository photoPathQueryRepository, PhotoPathBusinessRules photoPathBusinessRules,
          IMapper mapper)
        {
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;

            _photoPathCommandRepository = photoPathCommandRepository;
            _photoPathQueryRepository = photoPathQueryRepository;
            _photoPathBusinessRules = photoPathBusinessRules;

            _mapper = mapper;
        }

        public async Task<AddPhotoToCorporateAdvertCommandResponse> Handle(AddPhotoToCorporateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvertToCheck = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvertToCheck);
            await _corporateAdvertBusinessRules.CheckIfCorporateAdvertSold(corporateAdvertToCheck);

            var advertPhotoPathToCheck = await _photoPathQueryRepository.GetSingleAsync(e => e.PhotoPath == request.PhotoUrl);

            await _photoPathBusinessRules.ExistsCheck(advertPhotoPathToCheck);

            var advertPhotoPath = new AdvertPhotoPath() { AdvertId = corporateAdvertToCheck.AdvertId, PhotoPath = request.PhotoUrl };

            await _photoPathCommandRepository.AddAsync(advertPhotoPath);
            await _photoPathCommandRepository.SaveChangesAsync();

            var advertPhotoPathDto = _mapper.Map<AdvertPhotoPathDto>(advertPhotoPath);

            return new AddPhotoToCorporateAdvertCommandResponse(new SuccessfulContentResponse<AdvertPhotoPathDto>(advertPhotoPathDto, ResponseTitles.Success, ResponseMessages.PhotoAddedToAdvert, System.Net.HttpStatusCode.OK));

        }
    }
}
