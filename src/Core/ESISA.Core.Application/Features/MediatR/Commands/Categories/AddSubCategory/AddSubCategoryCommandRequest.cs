using ESISA.Core.Application.Features.MediatR.Commands.Categories.Add;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.AddSubCategory
{
    public class AddSubCategoryCommandRequest : IRequest<AddSubCategoryCommandResponse>
    {
        public Guid ParentCategoryId { get; set; }
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }
    }
}
