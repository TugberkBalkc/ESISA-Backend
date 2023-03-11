using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateBrandDemand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandDemandCommandRequest, CreateBrandDemandCommandResponse>
    {
        private readonly IBrandDemandCommandRepository _brandDemandCommandRepository;
        private readonly BrandDemandBusinessRules _brandDemandBusinessRules;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler
            (IBrandDemandCommandRepository brandDemandCommandRepository, BrandDemandBusinessRules brandDemandBusinessRules,
             IMapper mapper)
        {
            _brandDemandCommandRepository = brandDemandCommandRepository;
            _brandDemandBusinessRules = brandDemandBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateBrandDemandCommandResponse> Handle(CreateBrandDemandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandDemandBusinessRules.CheckIfDemandedBrandExistsByBrandName(request.BrandName);

            await _brandDemandBusinessRules.CheckIfBrandDemandExists(request.BrandName);

            var brandDemand = _mapper.Map<BrandDemand>(request);

            await _brandDemandCommandRepository.AddAsync(brandDemand);

            await _brandDemandCommandRepository.SaveChangesAsync();

            var brandDemandDto = _mapper.Map<BrandDemandDto>(brandDemand);

            return new CreateBrandDemandCommandResponse(new SuccessfulContentResponse<BrandDemandDto>(brandDemandDto, ResponseTitles.Success, ResponseMessages.DemandSent, System.Net.HttpStatusCode.OK));
        }
    }
}
