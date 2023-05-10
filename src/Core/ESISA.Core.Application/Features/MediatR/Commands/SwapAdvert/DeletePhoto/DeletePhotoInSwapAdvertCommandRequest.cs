using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.DeletePhoto
{
    public class DeletePhotoInSwapAdvertCommandRequest : IRequest<DeletePhotoInSwapAdvertCommandResponse>
    {
        public Guid SwapAdvertId { get; set; }
        public String PhotoUrl { get; set; }

        public DeletePhotoInSwapAdvertCommandRequest()
        {

        }

        public DeletePhotoInSwapAdvertCommandRequest(Guid swapAdvertId, string photoUrl)
        {
            SwapAdvertId = swapAdvertId;
            PhotoUrl = photoUrl;
        }
    }
}
