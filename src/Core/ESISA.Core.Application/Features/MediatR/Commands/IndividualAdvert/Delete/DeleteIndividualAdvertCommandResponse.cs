﻿using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete
{
    public class DeleteIndividualAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteIndividualAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
