using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Favorite
{
    public class CreateIndividualCustomerIndividualAdvertFavoriteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualAdvertId { get; set; }
    }
}
