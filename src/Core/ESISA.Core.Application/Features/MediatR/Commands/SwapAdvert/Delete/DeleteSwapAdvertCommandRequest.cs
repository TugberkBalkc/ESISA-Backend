using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Delete
{
    public class DeleteSwapAdvertCommandRequest : IRequest<DeleteSwapAdvertCommandResponse>
    {
        public Guid SwapAdvertId { get; set; }

        public DeleteSwapAdvertCommandRequest()
        {

        }

        public DeleteSwapAdvertCommandRequest(Guid swapAdvertId)
        {
            SwapAdvertId = swapAdvertId;
        }
    }
}
