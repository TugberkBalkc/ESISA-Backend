using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Constants
{
    public static class RabbitMQConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";


        //Comments Queue & Exchanges
        public const string CorporateCustomerWholesaleAdvertCommentExchangeName = "CorporateCustomerWholesaleAdvertCommentExchange";
        public const string IndividualCustomerCorporateAdvertCommentExchangeName = "IndividualCustomerCorporateAdvertCommentExchange";
        public const string CorporateCustomerCorporateDealerCommentExchangeName = "CorporateCustomerCorporateDealerCommentExchange";
        public const string IndividualCustomerIndividualDealerCommentExchangeName = "IndividualCustomerIndividualDealerCommentExchange";


        public const string CreateCorporateCustomerWholesaleAdvertCommentQueueName = "CreateCorporateCustomerWholesaleAdvertCommentQueue";
        public const string CreateIndividualCustomerCorporateAdvertCommentQueueName = "CreateIndividualCustomerCorporateAdvertCommentQueue";
        public const string CreateCorporateCustomerCorporateDealerCommentQueueName = "CreateCorporateCustomerCorporateDealerCommentQueue";
        public const string CreateIndividualCustomerIndividualDealerCommentQueueName = "CreateIndividualCustomerIndividualDealerCommentQueue";


        public const string DeleteCorporateCustomerWholesaleAdvertCommentQueueName = "DeleteCorporateCustomerWholesaleAdvertCommentQueue";
        public const string DeleteIndividualCustomerCorporateAdvertCommentQueueName = "DeleteIndividualCustomerCorporateAdvertCommentQueue";
        public const string DeleteCorporateCustomerCorporateDealerCommentQueueName = "DeleteCorporateCustomerCorporateDealerCommentQueue";
        public const string DeleteIndividualCustomerIndividualDealerCommentQueueName = "DeleteIndividualCustomerIndividualDealerCommentQueue";
        //End Of Comments Queue & Exchanges


        //Favorite Queue & Exchanges
        public const string CorporateCustomerWholesaleAdvertFavoriteExchangeName = "CorporateCustomerWholesaleAdvertFavoriteExchange";
        public const string IndividualCustomerCorporateAdvertFavoriteExchangeName = "IndividualCustomerCorporateAdvertFavoriteExchange";
        public const string IndividualCustomerIndividualAdvertFavoriteExchangeName = "IndividualCustomerIndividualAdvertFavoriteExchange";


        public const string CreateCorporateCustomerWholesaleAdvertFavoriteQueueName = "CreateCorporateCustomerWholesaleAdvertFavoriteQueue";
        public const string CreateIndividualCustomerCorporateAdvertFavoriteQueueName = "CreateIndividualCustomerCorporateAdvertFavoriteQueue";
        public const string CreateIndividualCustomerIndividualAdvertFavoriteQueueName = "CreateIndividualCustomerIndividualAdvertFavoriteQueue";


        public const string DeleteCorporateCustomerWholesaleAdvertFavoriteQueueName = "DeleteCorporateCustomerWholesaleAdvertFavoriteQueue";
        public const string DeleteIndividualCustomerCorporateAdvertFavoriteQueueName = "DeleteIndividualCustomerCorporateAdvertFavoriteQueue";
        public const string DeleteIndividualCustomerIndividualAdvertFavoriteQueueName = "DeleteIndividualCustomerIndividualAdvertFavoriteQueue";
        //End Of Favorite Queue & Exchanges


        //Vote Queue & Exchanges
        public const string CorporateCustomerWholesaleAdvertVoteExchangeName = "CorporateCustomerWholesaleAdvertVoteExchange";
        public const string IndividualCustomerCorporateAdvertVoteExchangeName = "IndividualCustomerCorporateAdvertVoteExchange";
        public const string IndividualCustomerIndividualDealerVoteExchangeName = "IndividualCustomerIndividualDealerVoteExchange";


        public const string CreateCorporateCustomerWholesaleAdvertVoteQueueName = "CreateCorporateCustomerWholesaleAdvertVoteQueue";
        public const string CreateIndividualCustomerCorporateAdvertVoteQueueName = "CreateIndividualCustomerCorporateAdvertVoteQueue";
        public const string CreateIndividualCustomerIndividualDealerVoteQueueName = "CreateIndividualCustomerIndividualDealerVoteQueue";


        public const string DeleteCorporateCustomerWholesaleAdvertVoteQueueName = "DeleteCorporateCustomerWholesaleAdvertVoteQueue";
        public const string DeleteIndividualCustomerCorporateAdvertVoteQueueName = "DeleteIndividualCustomerCorporateAdvertVoteQueue";
        public const string DeleteIndividualCustomerIndividualDealerVoteQueueName = "DeleteIndividualCustomerIndividualDealerVoteQueue";
        //End Of Vote Queue & Exchanges
    }
}
