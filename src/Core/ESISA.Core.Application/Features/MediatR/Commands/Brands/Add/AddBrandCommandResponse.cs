using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Add
{
    public class AddBrandCommandResponse : CommandResponseBase<BrandDto>
    {
        public AddBrandCommandResponse(IContentResponse<BrandDto> response) : base(response)
        {
        }
    }
}
