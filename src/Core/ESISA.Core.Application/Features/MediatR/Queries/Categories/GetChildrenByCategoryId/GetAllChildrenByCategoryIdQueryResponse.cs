using ESISA.Core.Application.Dtos.Category;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;
using ESISA.Core.Domain.Entities;

namespace ESISA.Core.Application.Features.MediatR.Queries.Categories.GetChildrenByCategoryId
{
    public class GetAllChildrenByCategoryIdQueryResponse : SingularQueryResponse<Category>
    {
        public GetAllChildrenByCategoryIdQueryResponse(IContentResponse<Category> response) : base(response)
        {
        }
    }

}
