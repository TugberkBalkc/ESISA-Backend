using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Add
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommandRequest, AddBrandCommandResponse>
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly IMapper _mapper;

        public AddBrandCommandHandler
            (IBrandCommandRepository brandCommandRepository, BrandBusinessRules brandBusinessRules,
             IMapper mapper)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandBusinessRules = brandBusinessRules;
            _mapper = mapper;
        }

        public async Task<AddBrandCommandResponse> Handle(AddBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.ExistsCheckByBrandName(request.BrandName);

            var brand = _mapper.Map<Brand>(request);

            await _brandCommandRepository.AddAsync(brand);

            await _brandCommandRepository.SaveChangesAsync();

            var brandDto = _mapper.Map<BrandDto>(brand);

            return new AddBrandCommandResponse(new SuccessfulContentResponse<BrandDto>(brandDto, ResponseTitles.Success, ResponseMessages.BrandAdded, System.Net.HttpStatusCode.OK));
        }
    }
}
