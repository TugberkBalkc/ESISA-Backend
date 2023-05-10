using BuildingBlocks.Constants;
using BuildingBlocks.Events.Favorite;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using Microsoft.Extensions.Configuration;
using WorkerServices.ESISAFavoriteService.Services;

namespace WorkerServices.ESISAFavoriteService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectionString = _configuration.GetSection("SqlServerDatabaseOptions").ToString(); ;

            var favoriteService = new FavoriteService(connectionString);

            await this.StartupFavoriteQueues(favoriteService);
        }

        private async Task StartupFavoriteQueues(IFavoriteService favoriteService)
        {
            RabbitMQFactory.CreateBasicConsumer()
                      .EnsureExchange(RabbitMQConstants.CorporateCustomerWholesaleAdvertFavoriteExchangeName)
                      .EnsureQueue(RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertFavoriteQueueName,
                                   RabbitMQConstants.CorporateCustomerWholesaleAdvertFavoriteExchangeName)
                      .Receive<CreateCorporateCustomerWholesaleAdvertFavoriteEvent>(@event =>
                      {
                          favoriteService.CreateCorporateCustomerWholesaleAdvertFavoriteAsync(@event).GetAwaiter().GetResult();
                      })
                      .StartConsuming(RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertFavoriteQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerCorporateAdvertFavoriteExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateIndividualCustomerCorporateAdvertFavoriteQueueName,
                                        RabbitMQConstants.IndividualCustomerCorporateAdvertFavoriteExchangeName)
                           .Receive<CreateIndividualCustomerCorporateAdvertFavoriteEvent>(@event =>
                           {
                               favoriteService.CreateIndividualCustomerCorporateAdvertFavoriteAsync(@event).GetAwaiter().GetResult();
                           })
                          .StartConsuming(RabbitMQConstants.CreateIndividualCustomerCorporateAdvertFavoriteQueueName);


            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerIndividualAdvertFavoriteExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateIndividualCustomerIndividualAdvertFavoriteQueueName,
                                        RabbitMQConstants.IndividualCustomerIndividualAdvertFavoriteExchangeName)
                           .Receive<CreateIndividualCustomerIndividualAdvertFavoriteEvent>(@event =>
                           {
                               favoriteService.CreateIndividualCustomerIndividualAdvertFavoriteAsync(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.CreateIndividualCustomerIndividualAdvertFavoriteQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                         .EnsureExchange(RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName)
                         .EnsureQueue(RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertVoteQueueName,
                                      RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName)
                         .Receive<DeleteCorporateCustomerWholesaleAdvertFavoriteEvent>(@event =>
                         {
                             favoriteService.DeleteCorporateCustomerWholesaleAdvertFavoriteAsync(@event).GetAwaiter().GetResult();
                         })
                         .StartConsuming(RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertVoteQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerCorporateAdvertFavoriteExchangeName)
                           .EnsureQueue(RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertFavoriteQueueName,
                                        RabbitMQConstants.IndividualCustomerCorporateAdvertFavoriteExchangeName)
                           .Receive<DeleteIndividualCustomerCorporateAdvertFavoriteEvent>(@event =>
                           {
                               favoriteService.DeleteIndividualCustomerCorporateAdvertFavoriteAsync(@event).GetAwaiter().GetResult();
                           })
                          .StartConsuming(RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertFavoriteQueueName);


            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerIndividualAdvertFavoriteExchangeName)
                           .EnsureQueue(RabbitMQConstants.DeleteIndividualCustomerIndividualAdvertFavoriteQueueName,
                                        RabbitMQConstants.IndividualCustomerIndividualAdvertFavoriteExchangeName)
                           .Receive<DeleteIndividualCustomerIndividualAdvertFavoriteEvent>(@event =>
                           {
                               favoriteService.DeleteIndividualCustomerIndividualAdvertFavoriteAsync(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.DeleteIndividualCustomerIndividualAdvertFavoriteQueueName);
        }
    }
}