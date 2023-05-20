using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Advert;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Services
{
    public class AdvertManager : IAdvertService
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ICategoryQueryRepository _categoryQueryRepository;
        
        private readonly IDealerQueryRepository _dealerQueryRepository;

        private readonly ICustomerQueryRepository _customerQueryRepository;

        private readonly IIndividualDealerQueryRepository _individualDealerQueryRepository;

        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;

        public AdvertManager(IAdvertQueryRepository advertQueryRepository, ICategoryQueryRepository categoryQueryRepository, IDealerQueryRepository dealerQueryRepository, ICustomerQueryRepository customerQueryRepository, IIndividualDealerQueryRepository individualDealerQueryRepository, IIndividualCustomerQueryRepository individualCustomerQueryRepository)
        {
            _advertQueryRepository = advertQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _dealerQueryRepository = dealerQueryRepository;
            _customerQueryRepository = customerQueryRepository;
            _individualDealerQueryRepository = individualDealerQueryRepository;
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
        }

        public void SetIndividualAdvertAdvertDetails(IQueryable<IndividualAdvert> individualAdverts, IList<IndividualAdvertDetailsDto> individualAdvertDetailsDtos)
        {
            var advertIds = individualAdverts.Select(e => e.AdvertId);

            var adverts = new List<Advert>();

            foreach (var advertId in advertIds)
            {
                var advert = _advertQueryRepository.GetByIdAsync(advertId).Result;

                adverts.Add(advert);
            }

            var advertTitles = adverts.Select(e => e.Title).ToArray();
            var advertDescriptions = adverts.Select(e => e.Description).ToArray();

            for (int i = 0; i < individualAdvertDetailsDtos.Count; i++)
            {
                individualAdvertDetailsDtos[i].AdvertTitle = advertTitles[i];
                individualAdvertDetailsDtos[i].AdvertDescription = advertDescriptions[i];
            }
        }

        public void SetIndividualAdvertCategoryDetails(IQueryable<IndividualAdvert> individualAdverts)
        {
            foreach (var individualAdvert in individualAdverts)
            {
                var cateogry = _categoryQueryRepository.GetByIdAsync(individualAdvert.Product.CategoryId).Result;

                individualAdvert.Product.Category = cateogry;
            }
        }

        public void SetIndividualAdvertDealerDetails(IQueryable<IndividualAdvert> individualAdverts, IList<IndividualAdvertDetailsDto> individualAdvertDetailsDtos)
        {
            var individualAdvertIndividualDealersDealerIds = individualAdverts.Select(e => e.IndividualDealer.DealerId);

            var dealers = new List<Dealer>();

            foreach (var dealerId in individualAdvertIndividualDealersDealerIds)
            {
                dealers.Add(_dealerQueryRepository.GetByIdAsync(dealerId).Result);
            }

            var dealersUserIds = dealers.Select(e => e.UserId);

            var customers = new List<Customer>();

            foreach (var userId in dealersUserIds)
            {
                customers.Add(_customerQueryRepository.GetSingleAsync(e => e.UserId == userId).Result);
            }

            var customerIds = customers.Select(e => e.Id);

            var individualCustomers = new List<IndividualCustomer>();

            foreach (var customerId in customerIds)
            {
                individualCustomers.Add(_individualCustomerQueryRepository.GetSingleAsync(e => e.CustomerId == customerId).Result);
            }

            var customerFirstNames = individualCustomers.Select(e => e.FirstName).ToArray();
            var customerLastNames = individualCustomers.Select(e => e.LastName).ToArray();

            for (int i = 0; i < individualAdvertDetailsDtos.Count; i++)
            {
                individualAdvertDetailsDtos[i].IndividualAdvertIndividualDealerFirstName = customerFirstNames[i];
                individualAdvertDetailsDtos[i].IndividualAdvertIndividualDealerLastName = customerLastNames[i];
            }
        }
    }
}
