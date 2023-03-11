using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler
            (IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository, BrandBusinessRules brandBusinessRules,
             IMapper mapper)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
            _brandBusinessRules = brandBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandQueryRepository.GetByIdAsync(request.BrandId);

            await _brandBusinessRules.NullCheck(brand);

            _mapper.Map(request, brand);

            _brandCommandRepository.Update(brand);
 
            await _brandCommandRepository.SaveChangesAsync();

            var brandDto = _mapper.Map<BrandDto>(brand);

            return new UpdateBrandCommandResponse(new SuccessfulContentResponse<BrandDto>(brandDto, ResponseTitles.Success, ResponseMessages.BrandUpdated, System.Net.HttpStatusCode.OK));
        }
    }
}
