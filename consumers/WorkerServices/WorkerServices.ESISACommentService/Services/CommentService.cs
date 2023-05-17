using BuildingBlocks.Events.Comment;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServices.ESISACommentService.Services
{
    public class CommentService : ICommentService
    {
        private readonly String _connectionString;

        public CommentService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateCorporateCustomerCorporateDealerCommentAsync(CreateCorporateCustomerCorporateDealerCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into CorporateCustomerCorporateDealerComments (Id, CorporateCustomerId, CorporateDealerId, Title, Content CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @CorporateCustomerId, @CorporateDealerId, @Title, @Content, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)", 
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CorporateCustomerId = @event.CorporateCustomerId,
                        CorporateDealerId = @event.CorporateDealerId,
                        Title = @event.Title,
                        Content = @event.Content,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateCorporateCustomerWholesaleAdvertCommentAsync(CreateCorporateCustomerWholesaleAdvertCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into CorporateCustomerWholesaleAdvertComments (Id, CorporateCustomerId, WholesaleAdvertId, Title, Content CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @CorporateCustomerId, @WholesaleAdvertId, @Title, @Content, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CorporateCustomerId = @event.CorporateCustomerId,
                        WholesaleAdvertId = @event.WholesaleAdvertId,
                        Title = @event.Title,
                        Content = @event.Content,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateIndividualCustomerCorporateAdvertCommentAsync(CreateIndividualCustomerCorporateAdvertCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into IndividualCustomerCorporateAdvertComments (Id, IndividualCustomerId, CorporateAdvertId, Title, Content CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @IndividualCustomerId, @CorporateAdvertId, @Title, @Content, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IndividualCustomerId = @event.IndividualCustomerId,
                        CorporateAdvertId = @event.CorporateAdvertId,
                        Title = @event.Title,
                        Content = @event.Content,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task CreateIndividualCustomerIndividualDealerCommentAsync(CreateIndividualCustomerIndividualDealerCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("insert into IndividualCustomerIndividualDealerComments (Id, IndividualCustomerId, IndividualDealerId, Title, Content CreatedDate, ModifiedDate, IsDeleted, IsActive) values (@Id, @IndividualCustomerId, @IndividualDealerId, @Title, @Content, @CreatedDate, @ModifiedDate, @IsDeleted, @IsActive)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IndividualCustomerId = @event.IndividualCustomerId,
                        IndividualDealerId = @event.IndividualDealerId,
                        Title = @event.Title,
                        Content = @event.Content,
                        IsDeleted = false,
                        IsActive = true
                    });
            }
        }

        public async Task DeleteCorporateCustomerCorporateDealerCommentAsync(DeleteCorporateCustomerCorporateDealerCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from CorporateCustomerDealerComments where CorporateCustomerId = @CorporateCustomerId AND CorporateDealerId = @CorporateDealerId AND Title=@Title AND Content=@Content",
                    new
                    {
                        CorporateCustomerId = @event.CorporateCustomerId,
                        CorporateDealerId = @event.CorporateDealerId,
                        Title = @event.Title,
                        Content = @event.Content
                    });
            }
        }

        public async Task DeleteCorporateCustomerWholesaleAdvertCommentAsync(DeleteCorporateCustomerWholesaleAdvertCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from CorporateCustomerWholesaleAdvertComments where CorporateCustomerId = @CorporateCustomerId AND WholesaleAdvertId = @WholesaleAdvertId AND Title=@Title AND Content=@Content",
                    new
                    {
                        CorporateCustomerId = @event.CorporateCustomerId,
                        WholesaleAdvertId = @event.WholesaleAdvertId,
                        Title = @event.Title,
                        Content = @event.Content
                    });
            }
        }

        public async Task DeleteIndividualCustomerCorporateAdvertCommentAsync(DeleteIndividualCustomerCorporateAdvertCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from IndividualCustomerCorporateAdvertComments where IndividualCustomerId = @IndividualCustomerId AND CorporateAdvertId = @CorporateAdvertId AND Title=@Title AND Content=@Content",
                    new
                    {
                        IndividualCustomerId = @event.IndividualCustomerId,
                        CorporateAdvertId = @event.CorporateAdvertId,
                        Title = @event.Title,
                        Content = @event.Content
                    });
            }
        }

        public async Task DeleteIndividualCustomerIndividualDealerCommentAsync(DeleteIndividualCustomerIndividualDealerCommentEvent @event)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("delete from IndividualCustomerIndividualDealerComments where IndividualCustomerId = @IndividualCustomerId AND IndividualDealerId = @IndividualDealerId AND Title=@Title AND Content=@Content",
                    new
                    {
                        IndividualCustomerId = @event.IndividualCustomerId,
                        IndividualDealerId = @event.IndividualDealerId,
                        Title = @event.Title,
                        Content = @event.Content
                    });
            }
        }
    }
}
