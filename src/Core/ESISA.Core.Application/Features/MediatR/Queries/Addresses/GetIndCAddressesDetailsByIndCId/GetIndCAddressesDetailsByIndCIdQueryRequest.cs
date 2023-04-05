using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndCAddressesByIndCId;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetIndCAddressesDetailsByIndCId
{
    public class GetIndCAddressesDetailsByIndCIdQueryRequest : IRequest<GetIndCAddressesDetailsByIndCIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid IndividualCustomerId { get; set; }

        public GetIndCAddressesDetailsByIndCIdQueryRequest()
        {

        }

        public GetIndCAddressesDetailsByIndCIdQueryRequest(int pageIndex, int pageSize, Guid individualCustomerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndividualCustomerId = individualCustomerId;
        }
    }
}
