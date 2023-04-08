using ESISA.Core.Application.Dtos.Brand;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Create
{
    public class CreateBrandCommandResponse : CommandResponseBase<BrandDto>
    {
        public CreateBrandCommandResponse(IContentResponse<BrandDto> response) : base(response)
        {
        }
    }
}
