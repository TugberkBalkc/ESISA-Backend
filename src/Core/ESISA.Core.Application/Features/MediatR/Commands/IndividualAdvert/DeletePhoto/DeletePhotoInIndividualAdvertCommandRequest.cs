using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto
{
    public class DeletePhotoInIndividualAdvertCommandRequest : IRequest<DeletePhotoInIndividualAdvertCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }
        public String PhotoUrl { get; set; }

        public DeletePhotoInIndividualAdvertCommandRequest()
        {

        }

        public DeletePhotoInIndividualAdvertCommandRequest(Guid ındividualAdvertId, string photoUrl)
        {
            IndividualAdvertId = ındividualAdvertId;
            PhotoUrl = photoUrl;
        }
    }
}
