using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.DeletePhoto
{
    public class DeletePhotoInCorporateAdvertCommandRequest : IRequest<DeletePhotoInCorporateAdvertCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }
        public String PhotoUrl { get; set; }

        public DeletePhotoInCorporateAdvertCommandRequest()
        {

        }

        public DeletePhotoInCorporateAdvertCommandRequest(Guid corporateAdvertId, string photoUrl)
        {
            CorporateAdvertId = corporateAdvertId;
            PhotoUrl = photoUrl;
        }
    }
}
