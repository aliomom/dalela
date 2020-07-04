using NawafizApp.Data.Configuration;
using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data
{
    internal class ApplicationDbContext : DbContext
    {
        internal ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString = "DefaultConnection")
        {
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }



        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<ExternalLogin> Logins { get; set; }
        public IDbSet<Language> Languages { get; set; }
        public IDbSet<Branch> Branchs { get; set; }
        public IDbSet<Break> Breaks { get; set; }
        public IDbSet<ClientOffer> ClientOffers { get; set; }
        public IDbSet<DeviceToken> DeviceTokens { get; set; }
        public IDbSet<Favourite> Favourites { get; set; }
        public IDbSet<Follower> Followers { get; set; }
        public IDbSet<GalleryPhoto> GalleryPhotos { get; set; }
        public IDbSet<MainCategoryDal> MainCategoryDals { get; set; }
        public IDbSet<Neighborhood> Neighborhoods { get; set; }
        public IDbSet<MainCategoryOffers> MainCategoryOfferss { get; set; }

        public IDbSet<Notification> Notifications { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<ShopDal> ShopDals { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<SubCategetoryOffers> SubCategetoryOfferss { get; set; }
        public IDbSet<SubCategoryDal> SubCategoryDals { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new BranchConfiguration());
            modelBuilder.Configurations.Add(new BreakConfiguration());
            modelBuilder.Configurations.Add(new ClientOfferConfiguration());
            modelBuilder.Configurations.Add(new DeviceTokenConfiguration());
            modelBuilder.Configurations.Add(new FavouriteConfiguration());
            modelBuilder.Configurations.Add(new FollowerConfiguration());
            modelBuilder.Configurations.Add(new GalleryPhotoConfiguration());
            modelBuilder.Configurations.Add(new MainCategoryDalConfiguration());
            modelBuilder.Configurations.Add(new MainCategoryOffersConfiguration());
            modelBuilder.Configurations.Add(new NeighborhoodConfigration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new ShopDalConfiguration());
            modelBuilder.Configurations.Add(new StateConfiguration());
            modelBuilder.Configurations.Add(new SubCategetoryOffersConfiguration());
            modelBuilder.Configurations.Add(new SubCategoryDalConfiguration());


        }
}

   

}
