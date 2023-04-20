using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto
{
    public class AddPhotoToIndividualAdvertCommandRequest : IRequest<AddPhotoToIndividualAdvertCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }
        public String PhotoUrl { get; set; }

        public AddPhotoToIndividualAdvertCommandRequest()
        {

        }

        public AddPhotoToIndividualAdvertCommandRequest(Guid ındividualAdvertId, string photoUrl)
        {
            IndividualAdvertId = ındividualAdvertId;
            PhotoUrl = photoUrl;
        }
    }
}
