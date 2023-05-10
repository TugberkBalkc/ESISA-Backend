using BuildingBlocks.Events.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServices.ESISAFavoriteService.Services
{
    public interface IFavoriteService
    {
        Task CreateCorporateCustomerWholesaleAdvertFavoriteAsync(CreateCorporateCustomerWholesaleAdvertFavoriteEvent @event);
        Task CreateIndividualCustomerCorporateAdvertFavoriteAsync(CreateIndividualCustomerCorporateAdvertFavoriteEvent @event);
        Task CreateIndividualCustomerIndividualAdvertFavoriteAsync(CreateIndividualCustomerIndividualAdvertFavoriteEvent @event);
        Task DeleteCorporateCustomerWholesaleAdvertFavoriteAsync(DeleteCorporateCustomerWholesaleAdvertFavoriteEvent @event);
        Task DeleteIndividualCustomerCorporateAdvertFavoriteAsync(DeleteIndividualCustomerCorporateAdvertFavoriteEvent @event);
        Task DeleteIndividualCustomerIndividualAdvertFavoriteAsync(DeleteIndividualCustomerIndividualAdvertFavoriteEvent @event);
    }
}
