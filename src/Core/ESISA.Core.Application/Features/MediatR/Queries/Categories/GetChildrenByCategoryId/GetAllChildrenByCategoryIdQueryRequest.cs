using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Categories.GetChildrenByCategoryId
{
    public class GetAllChildrenByCategoryIdQueryRequest : IRequest<GetAllChildrenByCategoryIdQueryResponse>
    {
        public Guid CategoryId { get; set; }

        public GetAllChildrenByCategoryIdQueryRequest()
        {

        }

        public GetAllChildrenByCategoryIdQueryRequest( Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }

}
