using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory
{
    public class CreateSubCategoryCommandRequest : IRequest<CreateSubCategoryCommandResponse>
    {
        public Guid ParentCategoryId { get; set; }
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }

        public CreateSubCategoryCommandRequest()
        {

        }

        public CreateSubCategoryCommandRequest(Guid parentCategoryId, string categoryName, string categoryDescription)
        {
            ParentCategoryId = parentCategoryId;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}
