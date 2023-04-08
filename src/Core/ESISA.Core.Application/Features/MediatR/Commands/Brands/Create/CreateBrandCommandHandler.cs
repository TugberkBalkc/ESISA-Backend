using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Brand;
using ESISA.Core.Application.Extensions;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler
            (IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository, BrandBusinessRules brandBusinessRules,
             IMapper mapper)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
            _brandBusinessRules = brandBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brandToCheck = await _brandQueryRepository.GetSingleAsync(e => e.Name == request.BrandName);

            await _brandBusinessRules.ExistsCheck(brandToCheck);

            var brand = _mapper.Map<Brand>(request);

            await _brandCommandRepository.AddAsync(brand);

            await _brandCommandRepository.SaveChangesAsync();

            var brandDto = _mapper.Map<BrandDto>(brand);

            return new CreateBrandCommandResponse(new SuccessfulContentResponse<BrandDto>(brandDto, ResponseTitles.Success, ResponseMessages.BrandCreated, System.Net.HttpStatusCode.Created));
        }
    }
}
