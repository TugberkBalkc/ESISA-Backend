using BuildingBlocks.Events.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServices.ESISACommentService.Services
{
    public interface ICommentService
    {
        Task CreateCorporateCustomerWholesaleAdvertCommentAsync(CreateCorporateCustomerWholesaleAdvertCommentEvent @event);
        Task CreateIndividualCustomerCorporateAdvertCommentAsync(CreateIndividualCustomerCorporateAdvertCommentEvent @event);
        Task CreateCorporateCustomerCorporateDealerCommentAsync(CreateCorporateCustomerCorporateDealerCommentEvent @event);
        Task CreateIndividualCustomerIndividualDealerCommentAsync(CreateIndividualCustomerIndividualDealerCommentEvent @event);

        Task DeleteCorporateCustomerWholesaleAdvertCommentAsync(DeleteCorporateCustomerWholesaleAdvertCommentEvent @event);
        Task DeleteIndividualCustomerCorporateAdvertCommentAsync(DeleteIndividualCustomerCorporateAdvertCommentEvent @event);
        Task DeleteCorporateCustomerCorporateDealerCommentAsync(DeleteCorporateCustomerCorporateDealerCommentEvent @event);
        Task DeleteIndividualCustomerIndividualDealerCommentAsync(DeleteIndividualCustomerIndividualDealerCommentEvent @event);

    }
}
