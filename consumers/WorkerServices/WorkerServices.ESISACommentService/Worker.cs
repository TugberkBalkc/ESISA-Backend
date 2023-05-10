using BuildingBlocks.Constants;
using BuildingBlocks.Events.Comment;
using BuildingBlocks.Events.Favorite;
using BuildingBlocks.QueueFactory;
using WorkerServices.ESISACommentService.Services;

namespace WorkerServices.ESISACommentService
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

            var commentService = new CommentService(connectionString);

            await this.StartupCommentQueues(commentService);
        }

        private async Task StartupCommentQueues(ICommentService commentService)
        {
            RabbitMQFactory.CreateBasicConsumer()
                      .EnsureExchange(RabbitMQConstants.CorporateCustomerWholesaleAdvertCommentExchangeName)
                      .EnsureQueue(RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertCommentQueueName,
                                   RabbitMQConstants.CorporateCustomerWholesaleAdvertCommentExchangeName)
                      .Receive<CreateCorporateCustomerWholesaleAdvertCommentEvent>(@event =>
                      {
                          commentService.CreateCorporateCustomerWholesaleAdvertCommentAsync(@event).GetAwaiter().GetResult();
                      })
                      .StartConsuming(RabbitMQConstants.CreateCorporateCustomerWholesaleAdvertCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.CorporateCustomerCorporateDealerCommentExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateCorporateCustomerCorporateDealerCommentQueueName,
                                        RabbitMQConstants.CorporateCustomerCorporateDealerCommentExchangeName)
                           .Receive<CreateCorporateCustomerCorporateDealerCommentEvent>(@event =>
                           {
                               commentService.CreateCorporateCustomerCorporateDealerCommentAsync(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.CreateCorporateCustomerCorporateDealerCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerCorporateAdvertCommentExchangeName)
                           .EnsureQueue(RabbitMQConstants.CreateIndividualCustomerCorporateAdvertCommentQueueName,
                                        RabbitMQConstants.IndividualCustomerCorporateAdvertCommentExchangeName)
                           .Receive<CreateIndividualCustomerCorporateAdvertCommentEvent>(@event =>
                           {
                               commentService.CreateIndividualCustomerCorporateAdvertCommentAsync(@event).GetAwaiter().GetResult();
                           })
                          .StartConsuming(RabbitMQConstants.CreateIndividualCustomerCorporateAdvertCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                          .EnsureExchange(RabbitMQConstants.IndividualCustomerIndividualDealerCommentExchangeName)
                          .EnsureQueue(RabbitMQConstants.CreateIndividualCustomerIndividualDealerCommentQueueName,
                                       RabbitMQConstants.IndividualCustomerIndividualDealerCommentExchangeName)
                          .Receive<CreateIndividualCustomerIndividualDealerCommentEvent>(@event =>
                          {
                              commentService.CreateIndividualCustomerIndividualDealerCommentAsync(@event).GetAwaiter().GetResult();
                          })
                          .StartConsuming(RabbitMQConstants.CreateIndividualCustomerIndividualDealerCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                       .EnsureExchange(RabbitMQConstants.CorporateCustomerWholesaleAdvertCommentExchangeName)
                       .EnsureQueue(RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertCommentQueueName,
                                    RabbitMQConstants.CorporateCustomerWholesaleAdvertCommentExchangeName)
                       .Receive<DeleteCorporateCustomerWholesaleAdvertCommentEvent>(@event =>
                       {
                           commentService.DeleteCorporateCustomerWholesaleAdvertCommentAsync(@event).GetAwaiter().GetResult();
                       })
                       .StartConsuming(RabbitMQConstants.DeleteCorporateCustomerWholesaleAdvertCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.CorporateCustomerCorporateDealerCommentExchangeName)
                           .EnsureQueue(RabbitMQConstants.DeleteCorporateCustomerCorporateDealerCommentQueueName,
                                        RabbitMQConstants.CorporateCustomerCorporateDealerCommentExchangeName)
                           .Receive<DeleteCorporateCustomerCorporateDealerCommentEvent>(@event =>
                           {
                               commentService.DeleteCorporateCustomerCorporateDealerCommentAsync(@event).GetAwaiter().GetResult();
                           })
                           .StartConsuming(RabbitMQConstants.DeleteCorporateCustomerCorporateDealerCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                           .EnsureExchange(RabbitMQConstants.IndividualCustomerCorporateAdvertCommentExchangeName)
                           .EnsureQueue(RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertCommentQueueName,
                                        RabbitMQConstants.IndividualCustomerCorporateAdvertCommentExchangeName)
                           .Receive<DeleteIndividualCustomerCorporateAdvertCommentEvent>(@event =>
                           {
                               commentService.DeleteIndividualCustomerCorporateAdvertCommentAsync(@event).GetAwaiter().GetResult();
                           })
                          .StartConsuming(RabbitMQConstants.DeleteIndividualCustomerCorporateAdvertCommentQueueName);

            RabbitMQFactory.CreateBasicConsumer()
                          .EnsureExchange(RabbitMQConstants.IndividualCustomerIndividualDealerCommentExchangeName)
                          .EnsureQueue(RabbitMQConstants.DeleteIndividualCustomerIndividualDealerCommentQueueName,
                                       RabbitMQConstants.IndividualCustomerIndividualDealerCommentExchangeName)
                          .Receive<DeleteIndividualCustomerIndividualDealerCommentEvent>(@event =>
                          {
                              commentService.DeleteIndividualCustomerIndividualDealerCommentAsync(@event).GetAwaiter().GetResult();
                          })
                          .StartConsuming(RabbitMQConstants.DeleteIndividualCustomerIndividualDealerCommentQueueName);

        }
    }