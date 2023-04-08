using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Demand;
using ESISA.Core.Application.Extensions;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateCategoryDemand
{
    public class CreateCategoryDemandCommandHandler : IRequestHandler<CreateCategoryDemandCommandRequest, CreateCategoryDemandCommandResponse>
    {
        private readonly ICategoryDemandCommandRepository _categoryDemandCommandRepository;
        private readonly ICategoryDemandQueryRepository _categoryDemandQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly CategoryDemandBusinessRules _categoryDemandBusinessRules;
        private readonly IMapper _mapper;

        public CreateCategoryDemandCommandHandler
            (ICategoryDemandCommandRepository categoryDemandCommandRepository, ICategoryDemandQueryRepository categoryDemandQueryRepository, ICategoryQueryRepository categoryQueryRepository, CategoryDemandBusinessRules categoryDemandBusinessRules,
             IMapper mapper)
        {
            _categoryDemandCommandRepository = categoryDemandCommandRepository;
            _categoryDemandQueryRepository = categoryDemandQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _categoryDemandBusinessRules = categoryDemandBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateCategoryDemandCommandResponse> Handle(CreateCategoryDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryToCheck = await _categoryQueryRepository.GetSingleAsync(e => e.Name == request.CategoryName);

            await _categoryDemandBusinessRules.ExistsCheck(categoryToCheck);

            var categoryDemandToCheck = await _categoryDemandQueryRepository.GetSingleAsync(e => e.CategoryName == request.CategoryName);

            await _categoryDemandBusinessRules.ExistsCheck(categoryDemandToCheck);

            var categoryDemand = _mapper.Map<CategoryDemand>(request);

            await _categoryDemandCommandRepository.AddAsync(categoryDemand);

            await _categoryDemandCommandRepository.SaveChangesAsync();

            var categoryDemandDto = _mapper.Map<CategoryDemandDto>(categoryDemand);

            return new CreateCategoryDemandCommandResponse(new SuccessfulContentResponse<CategoryDemandDto>(categoryDemandDto, ResponseTitles.Success, ResponseMessages.DemandSent, System.Net.HttpStatusCode.Created));
        }
    }
}
