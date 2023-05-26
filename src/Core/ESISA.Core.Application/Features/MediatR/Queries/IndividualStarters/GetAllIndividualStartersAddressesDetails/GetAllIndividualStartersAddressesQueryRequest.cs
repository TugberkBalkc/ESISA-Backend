using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualStarters.GetAllIndividualStartersAddressesDetails
{
    public class GetAllIndividualStartersAddressesDetailsQueryRequest : IRequest<GetAllIndividualStartersAddressesDetailsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid IndividualCustomerId { get; set; }

        public GetAllIndividualStartersAddressesDetailsQueryRequest()
        {

        }

        public GetAllIndividualStartersAddressesDetailsQueryRequest(int pageIndex, int pageSize, Guid ındividualCustomerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndividualCustomerId = ındividualCustomerId;
        }
    }
}
