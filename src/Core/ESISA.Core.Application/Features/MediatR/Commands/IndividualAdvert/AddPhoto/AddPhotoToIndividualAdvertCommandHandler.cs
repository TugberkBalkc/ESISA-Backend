using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto
{
    public class AddPhotoToIndividualAdvertCommandHandler : IRequestHandler<AddPhotoToIndividualAdvertCommandRequest, AddPhotoToIndividualAdvertCommandResponse>
    {
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;

        private readonly IAdvertPhotoPathCommandRepository _photoPathCommandRepository;
        private readonly IAdvertPhotoPathQueryRepository _photoPathQueryRepository;
        private readonly PhotoPathBusinessRules _photoPathBusinessRules;

        private readonly IMapper _mapper;
        public AddPhotoToIndividualAdvertCommandHandler(IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IAdvertPhotoPathCommandRepository photoPathCommandRepository, IAdvertPhotoPathQueryRepository photoPathQueryRepository, PhotoPathBusinessRules photoPathBusinessRules,
          IMapper mapper)
        {
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            
            _photoPathCommandRepository = photoPathCommandRepository;
            _photoPathQueryRepository  = photoPathQueryRepository;
            _photoPathBusinessRules = photoPathBusinessRules;

            _mapper = mapper;
        }

        public async Task<AddPhotoToIndividualAdvertCommandResponse> Handle(AddPhotoToIndividualAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var individualAdvertToCheck = await _individualAdvertQueryRepository.GetSingleAsync(e => e.Id == request.IndividualAdvertId);

            await _individualAdvertBusinessRules.NullCheck(individualAdvertToCheck);
            await _individualAdvertBusinessRules.CheckIfIndividualAdvertSold(individualAdvertToCheck);

            var advertPhotoPathToCheck = await _photoPathQueryRepository.GetSingleAsync(e => e.PhotoPath == request.PhotoUrl);

            await _photoPathBusinessRules.ExistsCheck(advertPhotoPathToCheck);

            var advertPhotoPath = new AdvertPhotoPath() { AdvertId = individualAdvertToCheck.AdvertId, PhotoPath = request.PhotoUrl };

            await _photoPathCommandRepository.AddAsync(advertPhotoPath);
            await _photoPathCommandRepository.SaveChangesAsync();

            var advertPhotoPathDto = _mapper.Map<AdvertPhotoPathDto>(advertPhotoPath);

            return new AddPhotoToIndividualAdvertCommandResponse(new SuccessfulContentResponse<AdvertPhotoPathDto>(advertPhotoPathDto, ResponseTitles.Success, ResponseMessages.PhotoAddedToAdvert, System.Net.HttpStatusCode.OK));

        }
    }
}
