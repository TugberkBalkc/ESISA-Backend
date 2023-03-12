using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.DeleteRange
{
    public class DeleteRangeBrandCommandHandler : IRequestHandler<DeleteRangeBrandCommandRequest, DeleteRangeBrandCommandResponse>
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly BrandBusinessRules _brandBusinessRules;

        public DeleteRangeBrandCommandHandler(IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository, BrandBusinessRules brandBusinessRules)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<DeleteRangeBrandCommandResponse> Handle(DeleteRangeBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brandsToCheck = new List<Brand>();

            request.BrandIds.ToList().ForEach(async id =>
            {
                brandsToCheck.Add(await _brandQueryRepository.GetByIdAsync(id));
            });

            await _brandBusinessRules.NullCheck(brandsToCheck.ToArray());

            await _brandCommandRepository.DeleteRangeAsync(request.BrandIds);

            await _brandCommandRepository.SaveChangesAsync();

            return new DeleteRangeBrandCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.BrandsDeleted, System.Net.HttpStatusCode.OK));

        }
    }
}
