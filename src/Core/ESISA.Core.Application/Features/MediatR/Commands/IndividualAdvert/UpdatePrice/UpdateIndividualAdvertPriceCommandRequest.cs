using AutoMapper;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice
{
    public class UpdateIndividualAdvertPriceCommandRequest : IRequest<UpdateIndividualAdvertPriceCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }

        public decimal UpdatedPrice { get; set; }

        public UpdateIndividualAdvertPriceCommandRequest()
        {

        }

        public UpdateIndividualAdvertPriceCommandRequest(Guid ındividualAdvertId, decimal updatedPrice)
        {
            IndividualAdvertId = ındividualAdvertId;
            UpdatedPrice = updatedPrice;
        }
    }

}
