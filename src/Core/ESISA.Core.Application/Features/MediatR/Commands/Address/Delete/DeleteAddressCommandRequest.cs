using AutoMapper;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Addresses.Delete
{
    public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>
    {
        public Guid AddressId { get; set; }

        public DeleteAddressCommandRequest()
        {

        }

        public DeleteAddressCommandRequest(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}
