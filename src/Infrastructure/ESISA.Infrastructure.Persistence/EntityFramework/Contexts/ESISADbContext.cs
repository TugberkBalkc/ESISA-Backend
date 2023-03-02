using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Contexts
{
    public class ESISADbContext : DbContext
    {

        //Address Tables
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        public DbSet<CorporateCustomerAddress> CorporateCustomerAddresses { get; set; }
        public DbSet<IndividualCustomerAddress> IndividualCustomerAddresses { get; set; }
        //End Of Address Tables


        //Advert Tables
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertPhotoPath> AdvertPhotoPaths { get; set; }

        public DbSet<CorporateAdvert> CorporateAdverts { get; set; }

        public DbSet<IndividualAdvert> IndividualAdverts { get; set; }

        public DbSet<SwapAdvert> SwapAdverts { get; set; }
        public DbSet<SwapAdvertSwapableCategory> SwapAdvertSwapableCategories { get; set; }
        public DbSet<SwapAdvertSwapableProduct> swapAdvertSwapableProducts { get; set; }

        public DbSet<WholesaleAdvert> WholesaleAdverts { get; set; }
        //End Of Advert Tables


        //Category Tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPhotoPath> CategoryPhotoPaths { get; set; }
        //End Of Category Tables


        //Evaluation Tables
        
        //Comment Tables
        public DbSet<CorporateCustomerWholesaleAdvertComment> CorporateCustomerWholesaleAdvertComments { get; set; }
        public DbSet<IndividualCustomerCorporateAdvertComment> IndividualCustomerCorporateAdvertComments { get; set; }

        public DbSet<CorporateCustomerCorporateDealerComment> CorporateCustomerCorporateDealerComments { get; set; }
        public DbSet<IndividualCustomerIndividualDealerComment> IndividualCustomerIndividualDealerComments { get; set; }
        //End Of Comment Table

        //Favorite
        public DbSet<CorporateCustomerWholesaleAdvertFavorite> CorporateCustomerWholesaleAdvertFavorites { get; set; }
        public DbSet<IndividualCustomerCorporateAdvertFavorite> IndividualCustomerCorporateAdvertFavorites { get; set; }
        public DbSet<IndividualCustomerIndividualAdvertFavorite> IndividualCustomerIndividualAdvertFavorites { get; set; }
        //End Of Favorite Tables

        //Vote
        public DbSet<CorporateCustomerWholesaleAdvertVote> CorporateCustomerWholesaleAdvertVotes { get; set; }
        public DbSet<IndividualCustomerCorporateAdvertVote> IndividualCustomerCorporateAdvertVotes { get; set; }
        public DbSet<IndividualCustomerIndividualDealerVote> IndividualCustomerIndividualDealerVotes { get; set; }
        //End Of Vote Tables

        //End Of Evaluation Tables


        //Identity Tables

        //Authorization
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleOperationClaim> RoleOperationClaims { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        //End Of Authorization Tables

        //Common
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<User> Users { get; set; }
        // End Of Common Tables

        //Customer
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        //End Of Customer Tables

        //Dealer
        public DbSet<CorporateDealer> CorporateDealers { get; set; }
        public DbSet<IndividualDealer> IndividualDealers { get; set; }
        //End Of Dealer Tables

        //End Of Identity Tables


        //Order

        //Common
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }
        public DbSet<ReturnedOrder> ReturnedOrders { get; set; }
        //End Of Common Tables

        //CorporateAdvertOrder
        public DbSet<IndividualCustomerCorporateAdvertOrder> CorporateAdvertOrders { get; set; }
        public DbSet<CorporateAdvertOrderItem> CorporateAdvertOrderItems { get; set; }
        //End Of CorporateAdvertOrder Tables

        //WholesaleAdvertOrder
        public DbSet<CorporateCustomerWholesaleAdvertOrder> WholesaleAdvertOrders { get; set; }
        public DbSet<WholesaleAdvertOrderItem> WholesaleAdvertOrderItems { get; set; }
        //End Of WholesaleAdvertOrder Tables

        //End Of Order Tables


        //Product
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandPhotoPath> BrandPhotoPaths { get; set; }
        public DbSet<Product> Products { get; set; }
        //End Of Product Tables


        //Discount Tables
        public DbSet<PurchaseQuantityDiscount> PurchaseQuantityDiscounts { get; set; }
        public DbSet<UpperOrderPriceDiscount> UpperOrderPriceDiscounts { get; set; }
        // End Of Discount Tables


        public ESISADbContext()
        {

        }

        public ESISADbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public override int SaveChanges()
        {
            this.SetAddedEntities(this.GetEntitiesByState(EntityState.Added));
            this.SetUpdatedEntities(this.GetEntitiesByState(EntityState.Modified));
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.SetAddedEntities(this.GetEntitiesByState(EntityState.Added));
            this.SetUpdatedEntities(this.GetEntitiesByState(EntityState.Modified));
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.SetAddedEntities(this.GetEntitiesByState(EntityState.Added));
            this.SetUpdatedEntities(this.GetEntitiesByState(EntityState.Modified));
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.SetAddedEntities(this.GetEntitiesByState(EntityState.Added));
            this.SetUpdatedEntities(this.GetEntitiesByState(EntityState.Modified));
            return base.SaveChangesAsync(cancellationToken);
        }


        private IEnumerable<EntityBase> GetEntitiesByState(EntityState entityState)
        {
            return ChangeTracker.Entries<EntityBase>().Where(e => e.State == entityState).Select(e => (EntityBase)e.Entity).ToList();
        }

        private void SetAddedEntities(IEnumerable<EntityBase> entities)
        {
            entities.ToList().ForEach(e =>
            {
                if(e.CreatedDate == DateTime.MinValue)
                {
                    e.Id = Guid.NewGuid();
                    e.CreatedDate = DateTime.Now;
                    e.ModifiedDate = DateTime.Now;
                    e.IsDeleted = false;
                    e.IsActive = true;
                }
            });
        }

        private void SetUpdatedEntities(IEnumerable<EntityBase> entities)
        {
            entities.ToList().ForEach(e =>
            {
                if (e.Id != Guid.Empty)
                 e.ModifiedDate = DateTime.Now;
            });
        }
    }
}
