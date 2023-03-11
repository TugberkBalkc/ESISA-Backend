using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Delete
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, DeleteBrandCommandResponse>
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly BrandBusinessRules _brandBusinessRules;

        public DeleteBrandCommandHandler(IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository, BrandBusinessRules brandBusinessRules)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brandToCheck = await _brandQueryRepository.GetByIdAsync(request.BrandId);

            await _brandBusinessRules.NullCheck(brandToCheck);

            await _brandCommandRepository.DeleteAsync(request.BrandId);

            await _brandCommandRepository.SaveChangesAsync();

            return new DeleteBrandCommandResponse(new SuccessfulContentResponse<Guid>(request.BrandId, ResponseTitles.Success, ResponseMessages.BrandDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
