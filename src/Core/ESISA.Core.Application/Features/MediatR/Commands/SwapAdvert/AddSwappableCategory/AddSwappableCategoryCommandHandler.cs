using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableCategory
{
    public class AddSwappableCategoryCommandHandler :
        IRequestHandler<AddSwappableCategoryCommandRequest, AddSwappableCategoryCommandResponse>
    {
        private readonly ISwapAdvertSwapableCategoryCommandRepository _swapAdvertSwapableCategoryCommandRepository;
        private readonly ISwapAdvertSwapableCategoryQueryRepository _swapAdvertSwapableCategoryQueryRepository;
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;
        private readonly IMapper _mapper;

        public AddSwappableCategoryCommandHandler(ISwapAdvertSwapableCategoryCommandRepository swapAdvertSwapableCategoryCommandRepository, ISwapAdvertSwapableCategoryQueryRepository swapAdvertSwapableCategoryQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IMapper mapper, ISwapAdvertQueryRepository swapAdvertQueryRepository, ICategoryQueryRepository categoryQueryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _swapAdvertSwapableCategoryCommandRepository = swapAdvertSwapableCategoryCommandRepository;
            _swapAdvertSwapableCategoryQueryRepository = swapAdvertSwapableCategoryQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;
            _mapper = mapper;
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<AddSwappableCategoryCommandResponse> Handle(AddSwappableCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryQueryRepository.GetByIdAsync(request.CategoryId);

            await _categoryBusinessRules.NullCheck(category);

            var swapAdvert = await _swapAdvertQueryRepository.GetByIdAsync(request.SwapAdvertId);

            await _swapAdvertBusinessRules.NullCheck(swapAdvert);

            var swapAdvertSwappableCategoryToCheck = await _swapAdvertSwapableCategoryQueryRepository.GetSingleAsync(e => e.CategoryId == request.CategoryId && e.SwapAdvertId == request.SwapAdvertId);

            await _swapAdvertBusinessRules.ExistsCheck(swapAdvertSwappableCategoryToCheck);
            await _swapAdvertBusinessRules.CheckIfSwapAdvertActive(swapAdvert);

            var swapAdvertSwappableCateogry = _mapper.Map<SwapAdvertSwapableCategory>(request);

            await _swapAdvertSwapableCategoryCommandRepository.AddAsync(swapAdvertSwappableCateogry);
            await _swapAdvertSwapableCategoryCommandRepository.SaveChangesAsync();

            var swapAdvertSwappableCategoryDto = _mapper.Map<SwapAdvertSwappableCategoryDto>(swapAdvertSwappableCateogry);

            return new AddSwappableCategoryCommandResponse(new SuccessfulContentResponse<SwapAdvertSwappableCategoryDto>(swapAdvertSwappableCategoryDto, ResponseTitles.Success, ResponseMessages.CategoryAddedToSwappableList, HttpStatusCode.Created));
        }
    }
}
