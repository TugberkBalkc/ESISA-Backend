using BuildingBlocks.Events.Vote;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServices.ESISAVoteService.Services
{
    public class VoteService : IVoteService
    {
        private readonly String _connectionString;

        public VoteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateCorporateCustomerWholesaleAdvertVote(CreateCorporateCustomerWholesaleAdvertVoteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into CorporateCustomerWholesaleAdvertVotes (Id, CorporateCustomerId, WholesaleAdvertId, VoteType, CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @CorporateCustomerId, @WholesaleAdvertId, @VoteType, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CorporateCustomerId = @event.CorporateCustomerId,
                        WholesaleAdvertId =  @event.WholesaleAdvertId,
                        VoteType = @event.VoteType,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateIndividualCustomerCorporateAdvertVote(CreateIndividualCustomerCorporateAdvertVoteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into IndividualCustomerCorporateAdvertVotes (Id, IndividualCustomerId, CorporateAdvertId, VoteType, CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @IndividualCustomerId, @CorporateAdvertId, @VoteType, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IndividualCustomerId = @event.IndividualCustomerId,
                        CorporateAdvertId = @event.CorporateAdvertId,
                        VoteType = @event.VoteType,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateIndividualCustomerIndividualDealerVote(CreateIndividualCustomerIndividualDealerVoteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into IndividualCustomerIndividualDealerVotes (Id, IndividualCustomerId, IndividualDealerId, VoteType, CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @IndividualCustomerId, @IndividualDealerId, @VoteType, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IndividualCustomerId = @event.IndividualCustomerId,
                        IndividualDealerId = @event.IndividualDealerId,
                        VoteType = @event.VoteType,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task DeleteCorporateCustomerWholesaleAdvertVote(DeleteCorporateCustomerWholesaleAdvertVoteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from CorporateCustomerWholesaleAdvertVotes where CorporateCustomerId = @CorporateCustomerId AND WholesaleAdvertId = @WholesaleAdvertId",
                    new
                    {                   
                        CorporateCustomerId = @event.CorporateCustomerId,
                        WholesaleAdvertId = @event.WholesaleAdvertId
                    });
            }
        }

        public async Task DeleteIndividualCustomerCorporateAdvertVote(DeleteIndividualCustomerCorporateAdvertVoteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from IndividualCustomerCorporateAdvertVotes where IndividualCustomerId = @IndividualCustomerId AND CorporateAdvertId = @CorporateAdvertId",
                    new
                    {
                        IndividualCustomerId = @event.IndividualCustomerId,
                        CorporateAdvertId = @event.CorporateAdvertId
                    });
            }
        }
        
        public async Task DeleteIndividualCustomerIndividualDealerVote(DeleteIndividualCustomerIndividualDealerVoteEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from IndividualCustomerIndividualDealerVotes where IndividualCustomerId = @IndividualCustomerId AND IndividualDealerId = @IndividualDealerId",
                    new
                    {
                        IndividualCustomerId = @event.IndividualCustomerId,
                        IndividualDealerId = @event.IndividualDealerId
                    });
            }
        }
    }
}
