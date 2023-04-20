using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Update
{
    public class UpdateNotDiscountedCorporateAdvertCommandRequest : IRequest<UpdateNotDiscountedCorporateAdvertCommandResponse>
    {
    }

    public class UpdateNotDiscountedCorporateAdvertCommandResponse : CommandResponseBase<NotDiscountedCorporateAdvertDto>
    {
        public UpdateNotDiscountedCorporateAdvertCommandResponse(IContentResponse<NotDiscountedCorporateAdvertDto> response) : base(response)
        {
        }
    }

    public class UpdateNotDiscountedCorporateAdvertCommandHandler : IRequestHandler<UpdateNotDiscountedCorporateAdvertCommandRequest, UpdateNotDiscountedCorporateAdvertCommandResponse>
    {
        public Task<UpdateNotDiscountedCorporateAdvertCommandResponse> Handle(UpdateNotDiscountedCorporateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
