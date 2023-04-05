using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndCAddressesByIndCId
{
    public class GetAllIndCAddressesByIndCIdQueryRequest : IRequest<GetAllIndCAddressesByIndCIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid IndividualCustomerId { get; set; }

        public GetAllIndCAddressesByIndCIdQueryRequest()
        {

        }

        public GetAllIndCAddressesByIndCIdQueryRequest(int pageIndex, int pageSize, Guid individualCustomerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndividualCustomerId = individualCustomerId;
        }
    }
}
