using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Update
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; }
        public Guid ParentCategoryId { get; set; }
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }

        public UpdateCategoryCommandRequest()
        {

        }

        public UpdateCategoryCommandRequest(Guid categoryId, Guid parentCategoryId, string categoryName, string categoryDescription)
        {
            CategoryId = categoryId;
            ParentCategoryId = parentCategoryId;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}
