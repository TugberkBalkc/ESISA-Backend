using BuildingBlocks.Events.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServices.ESISAVoteService.Services
{
    public interface IVoteService
    {
        Task CreateCorporateCustomerWholesaleAdvertVote(CreateCorporateCustomerWholesaleAdvertVoteEvent @event);
        Task DeleteCorporateCustomerWholesaleAdvertVote(DeleteCorporateCustomerWholesaleAdvertVoteEvent @event);

        Task CreateIndividualCustomerCorporateAdvertVote(CreateIndividualCustomerCorporateAdvertVoteEvent @event);
        Task DeleteIndividualCustomerCorporateAdvertVote(DeleteIndividualCustomerCorporateAdvertVoteEvent @event);

        Task CreateIndividualCustomerIndividualDealerVote(CreateIndividualCustomerIndividualDealerVoteEvent @event);
        Task DeleteIndividualCustomerIndividualDealerVote(DeleteIndividualCustomerIndividualDealerVoteEvent @event);
    }
}
