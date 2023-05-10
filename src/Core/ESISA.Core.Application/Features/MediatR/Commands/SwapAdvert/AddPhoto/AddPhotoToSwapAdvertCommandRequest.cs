using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddPhoto
{
    public class AddPhotoToSwapAdvertCommandRequest : IRequest<AddPhotoToSwapAdvertCommandResponse>
    {
        public Guid SwapAdvertId { get; set; }
        public String PhotoUrl { get; set; }

        public AddPhotoToSwapAdvertCommandRequest()
        {

        }

        public AddPhotoToSwapAdvertCommandRequest(Guid swapAdvertId, string photoUrl)
        {
            SwapAdvertId = swapAdvertId;
            PhotoUrl = photoUrl;
        }
    }
}
