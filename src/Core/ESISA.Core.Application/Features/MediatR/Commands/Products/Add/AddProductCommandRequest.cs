using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Add
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        public String ProductName { get; set; }
    }
}
