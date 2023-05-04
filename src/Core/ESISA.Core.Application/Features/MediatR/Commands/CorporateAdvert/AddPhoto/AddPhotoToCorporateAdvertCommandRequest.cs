using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.AddPhoto
{
    public class AddPhotoToCorporateAdvertCommandRequest : IRequest<AddPhotoToCorporateAdvertCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }
        public String PhotoUrl { get; set; }

        public AddPhotoToCorporateAdvertCommandRequest()
        {

        }

        public AddPhotoToCorporateAdvertCommandRequest(Guid corporateAdvertId, string photoUrl)
        {
            CorporateAdvertId = corporateAdvertId;
            PhotoUrl = photoUrl;
        }
    }
}
