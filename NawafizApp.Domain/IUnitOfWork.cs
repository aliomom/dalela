using NawafizApp.Domain.Entities;
using NawafizApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NawafizApp.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IRepository<Language> LanguageRepository { get; }
        IRepository<Branch> BranchRepository { get; }
        IRepository<Break> BreakRepository { get; }
        IRepository<ClientOffer> ClientOfferRepository { get; }
        IRepository<DeviceToken> DeviceTokenRepository { get; }
        IRepository<Favourite> FavouriteRepository { get; }
        IRepository<Follower> FollowerRepository { get; }
        IRepository<GalleryPhoto> GalleryPhotoRepository { get; }
        IRepository<MainCategoryDal> MainCategoryDalRepository { get; }
        IRepository<MainCategoryOffers> MainCategoryOffersRepository { get; }
        IRepository<Neighborhood> NeighborhoodRepository { get; }
        IRepository<Notification> NotificationRepository { get; }
        IRepository<Offer> OfferRepository { get; }
        IRepository<Region> RegionRepository { get; }
        IRepository<ShopDal> ShopDalRepository { get; }
        IRepository<State> StateRepository { get; }
        IRepository<SubCategoryDal> SubCategoryDalRepository { get; }
        IRepository<SubCategetoryOffers> SubCategetoryOffersRepository { get; }
        



        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
