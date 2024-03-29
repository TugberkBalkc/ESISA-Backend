﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Create
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public String ProductName { get; set; }

        public CreateProductCommandRequest()
        {

        }

        public CreateProductCommandRequest(Guid categoryId, Guid brandId, string productName)
        {
            CategoryId = categoryId;
            BrandId = brandId;
            ProductName = productName;
        }
    }
}
