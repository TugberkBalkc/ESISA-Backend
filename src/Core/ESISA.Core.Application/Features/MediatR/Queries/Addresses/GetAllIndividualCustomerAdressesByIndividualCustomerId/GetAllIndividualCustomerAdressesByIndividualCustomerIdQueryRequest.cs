using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistrictsByCityId;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndividualCustomerAdressesByIndividualCustomerId
{
    public class GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest : IRequest<GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid IndividualCustomerId { get; set; }
        public GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest()
        {


        }
        public GetAllIndividualCustomerAdressesByIndividualCustomerIdQueryRequest(int pageIndex, int pageSize, Guid individualCustomerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndividualCustomerId = individualCustomerId;
        }
    
    }
}
