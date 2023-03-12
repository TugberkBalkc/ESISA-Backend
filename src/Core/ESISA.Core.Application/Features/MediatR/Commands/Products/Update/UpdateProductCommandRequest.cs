using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Update
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public Guid ProductId { get; set; }
        public bool ProductIsActive { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public String ProductName { get; set; }

        public UpdateProductCommandRequest()
        {

        }

        public UpdateProductCommandRequest(Guid productId, bool productIsActive, Guid categoryId, Guid brandId, string productName)
        {
            ProductId = productId;
            ProductIsActive = productIsActive;
            CategoryId = categoryId;
            BrandId = brandId;
            ProductName = productName;
        }
    }
}
