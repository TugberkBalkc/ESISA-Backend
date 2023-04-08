using ESISA.Core.Application.Dtos.Brand;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Update
{
    public class UpdateBrandCommandResponse : CommandResponseBase<BrandDto>
    {
        public UpdateBrandCommandResponse(IContentResponse<BrandDto> response) : base(response)
        {
        }
    }
}
