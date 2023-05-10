using BuildingBlocks.Constants;
using BuildingBlocks.Events.Vote;
using BuildingBlocks.QueueFactory;
using WorkerServices.ESISAVoteService.Services;

namespace WorkerServices.ESISAVoteService
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

            var voteService = new VoteService(connectionString);

            await this.StartupVoteQueues(voteService);
        }
        
        private async Task StartupVoteQueues(IVoteService voteService)
        {

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertVoteQueueName,
                                        RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName)
                           .Receive<CreateCorporateCustomerWholesaleAdvertVoteEvent>(@event =>
                           {
                               voteService.CreateCorporateCustomerWholesaleAdvertVote(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertVoteQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerCorporateAdvertVoteExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateIndividualCustomerCorporateAdvertVoteQueueName,
                                        RabbitMQConstants.IndividualCustomerCorporateAdvertVoteExchangeName)
                           .Receive<CreateIndividualCustomerCorporateAdvertVoteEvent>(@event =>
                           {
                               voteService.CreateIndividualCustomerCorporateAdvertVote(@event).GetAwaiter().GetResult();
                           })
                          .StartConsuming(RabbitMQConstants.CreateIndividualCustomerCorporateAdvertVoteQueueName);


            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerIndividualDealerVoteExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateIndividualCustomerIndividualDealerVoteQueueName,
                                        RabbitMQConstants.IndividualCustomerIndividualDealerVoteExchangeName)
                           .Receive<CreateIndividualCustomerIndividualDealerVoteEvent>(@event =>
                           {
                               voteService.CreateIndividualCustomerIndividualDealerVote(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.CreateIndividualCustomerIndividualDealerVoteQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                         .EnsureExchange(RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName)
                         .EnsureQueue(RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertVoteQueueName,
                                      RabbitMQConstants.CorporateCustomerWholesaleAdvertVoteExchangeName)
                         .Receive<DeleteCorporateCustomerWholesaleAdvertVoteEvent>(@event =>
                         {
                             voteService.DeleteCorporateCustomerWholesaleAdvertVote(@event).GetAwaiter().GetResult();
                         })
                         .StartConsuming(RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertVoteQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerCorporateAdvertVoteExchangeName)
                           .EnsureQueue(RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertVoteQueueName,
                                        RabbitMQConstants.IndividualCustomerCorporateAdvertVoteExchangeName)
                           .Receive<DeleteIndividualCustomerCorporateAdvertVoteEvent>(@event =>
                           {
                               voteService.DeleteIndividualCustomerCorporateAdvertVote(@event).GetAwaiter().GetResult();
                           })
                          .StartConsuming(RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertVoteQueueName);


            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerIndividualDealerVoteExchangeName)
                           .EnsureQueue(RabbitMQConstants.DeleteIndividualCustomerIndividualDealerVoteQueueName,
                                        RabbitMQConstants.IndividualCustomerIndividualDealerVoteExchangeName)
                           .Receive<DeleteIndividualCustomerIndividualDealerVoteEvent>(@event =>
                           {
                               voteService.DeleteIndividualCustomerIndividualDealerVote(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.DeleteIndividualCustomerIndividualDealerVoteQueueName);
        }
    }
}