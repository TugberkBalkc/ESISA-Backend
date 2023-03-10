﻿using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Add
{
    public class AddProductCommandResponse : CommandResponseBase<ProductDto>
    {
        public AddProductCommandResponse(IContentResponse<ProductDto> response) : base(response)
        {
        }
    }
}