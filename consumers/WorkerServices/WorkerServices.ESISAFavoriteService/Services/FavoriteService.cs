using BuildingBlocks.Events.Favorite;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServices.ESISAFavoriteService.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly String _connectionString;

        public FavoriteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateCorporateCustomerWholesaleAdvertFavoriteAsync(CreateCorporateCustomerWholesaleAdvertFavoriteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into CorporateCustomerWholesaleAdvertFavorites (Id, CorporateCustomerId, WholesaleAdvertId, CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @CorporateCustomerId, @WholesaleAdvertId, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CorporateCustomerId = @event.CorporateCustomerId,
                        WholesaleAdvertId = @event.WholesaleAdvertId,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateIndividualCustomerCorporateAdvertFavoriteAsync(CreateIndividualCustomerCorporateAdvertFavoriteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into IndividualCustomerCorporateAdvertFavorites (Id, IndividualCustomerId, CorporateAdvertId, CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @IndividualCustomerId, @CorporateAdvertId, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IndividualCustomerId = @event.IndividualCustomerId,
                        CorporateAdvertId = @event.CorporateAdvertId,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateIndividualCustomerIndividualAdvertFavoriteAsync(CreateIndividualCustomerIndividualAdvertFavoriteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into IndividualCustomerIndividualAdvertFavorites (Id, IndividualCustomerId, IndividualAdvertId, CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @IndividualCustomerId, @IndividualAdvertId, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IndividualCustomerId = @event.IndividualCustomerId,
                        IndividualAdvertId = @event.IndividualAdvertId,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task DeleteCorporateCustomerWholesaleAdvertFavoriteAsync(DeleteCorporateCustomerWholesaleAdvertFavoriteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from CorporateCustomerWholesaleAdvertFavorites where CorporateCustomerId = @CorporateCustomerId AND WholesaleAdvertId = @WholesaleAdvertId",
                    new
                    {
                        CorporateCustomerId = @event.CorporateCustomerId,
                        WholesaleAdvertId = @event.WholesaleAdvertId
                    });
            }
        }

        public async Task DeleteIndividualCustomerCorporateAdvertFavoriteAsync(DeleteIndividualCustomerCorporateAdvertFavoriteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from IndividualCustomerCorporateAdvertFavorites where IndividualCustomerId = @IndividualCustomerId AND CorporateAdvertId = @CorporateAdvertId",
                    new
                    {
                        IndividualCustomerId = @event.IndividualCustomerId,
                        CorporateAdvertId = @event.CorporateAdvertId
                    });
            }
        }

        public async Task DeleteIndividualCustomerIndividualAdvertFavoriteAsync(DeleteIndividualCustomerIndividualAdvertFavoriteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from IndividualCustomerIndividualAdvertFavorites where IndividualCustomerId = @IndividualCustomerId AND IndividualAdvertId = @IndividualAdvertId",
                    new
                    {
                        IndividualCustomerId = @event.IndividualCustomerId,
                        IndividualAdvertId = @event.IndividualAdvertId
                    });
            }
        }
    }
}
