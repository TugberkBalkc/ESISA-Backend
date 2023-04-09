using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.Update
{
    public class UpdateIndividualStarterCommandRequest : IRequest<UpdateIndividualStarterCommandResponse>
    {
    }
    public class UpdateIndividualStarterCommandResponse : CommandResponseBase<IndividualStarterDto>
    {
        public UpdateIndividualStarterCommandResponse(IContentResponse<IndividualStarterDto> response) : base(response)
        {
        }
    }
    public class UpdateIndividualStarterCommandHandler : IRequestHandler<UpdateIndividualStarterCommandRequest, UpdateIndividualStarterCommandResponse>
    {
        public Task<UpdateIndividualStarterCommandResponse> Handle(UpdateIndividualStarterCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
