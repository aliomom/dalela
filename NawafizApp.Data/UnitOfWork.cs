using NawafizApp.Data.Repositories;
using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IRepository<Language> _languageRepository;
        private IRepository<Branch> _BranchRepository;
        private IRepository<Break> _BreakRepository;
        private IRepository<ClientOffer> _ClientOfferRepository;
        private IRepository<DeviceToken> _DeviceTokenRepository;
        private IRepository<Favourite> _FavouriteRepository;
        private IRepository<Follower> _FollowerRepository;
        private IRepository<GalleryPhoto> _GalleryPhotoRepository;
        private IRepository<MainCategoryDal> _MainCategoryDalRepository;
        private IRepository<MainCategoryOffers> _MainCategoryOffersRepository;
        private IRepository<Neighborhood> _NeighborhoodRepository;
        private IRepository<Notification> _NotificationRepository;
        private IRepository<Offer> _OfferRepository;
        private IRepository<Region> _RegionRepository;
        private IRepository<ShopDal> _ShopDalRepository;
        private IRepository<State> _StateRepository;

        private IRepository<SubCategoryDal> _SubCategoryDalRepository;
        private IRepository<SubCategetoryOffers> _SubCategetoryOffersRepository;
      

        #endregion

        #region Constructors
        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new ApplicationDbContext(nameOrConnectionString);
        }
        #endregion

        #region IUnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public IRepository<Language> LanguageRepository
        {
            get { return _languageRepository ?? (_languageRepository = new Repository<Language>(_context)); }
        }
        public IRepository<Branch> BranchRepository
        {
            get { return _BranchRepository ?? (_BranchRepository = new Repository<Branch>(_context)); }
        }
        public IRepository<Break> BreakRepository
        {
            get { return _BreakRepository ?? (_BreakRepository = new Repository<Break>(_context)); }
        }
        public IRepository<ClientOffer> ClientOfferRepository
        {
            get { return _ClientOfferRepository ?? (_ClientOfferRepository = new Repository<ClientOffer>(_context)); }
        }
        public IRepository<DeviceToken> DeviceTokenRepository
        {
            get { return _DeviceTokenRepository ?? (_DeviceTokenRepository = new Repository<DeviceToken>(_context)); }
        }
        public IRepository<Favourite> FavouriteRepository
        {
            get { return _FavouriteRepository ?? (_FavouriteRepository = new Repository<Favourite>(_context)); }
        }
        public IRepository<Follower> FollowerRepository
        {
            get { return _FollowerRepository ?? (_FollowerRepository = new Repository<Follower>(_context)); }
        }
        public IRepository<GalleryPhoto> GalleryPhotoRepository
        {
            get { return _GalleryPhotoRepository ?? (_GalleryPhotoRepository = new Repository<GalleryPhoto>(_context)); }
        }
        public IRepository<MainCategoryDal> MainCategoryDalRepository
        {
            get { return _MainCategoryDalRepository ?? (_MainCategoryDalRepository = new Repository<MainCategoryDal>(_context)); }
        }
        public IRepository<SubCategoryDal> SubCategoryDalRepository
        {
            get { return _SubCategoryDalRepository ?? (_SubCategoryDalRepository = new Repository<SubCategoryDal>(_context)); }
        }
        public IRepository<SubCategetoryOffers> SubCategetoryOffersRepository
        {
            get { return _SubCategetoryOffersRepository ?? (_SubCategetoryOffersRepository = new Repository<SubCategetoryOffers>(_context)); }
        }
        public IRepository<MainCategoryOffers> MainCategoryOffersRepository
        {
            get { return _MainCategoryOffersRepository ?? (_MainCategoryOffersRepository = new Repository<MainCategoryOffers>(_context)); }
        }
        public IRepository<Neighborhood> NeighborhoodRepository
        {
            get { return _NeighborhoodRepository ?? (_NeighborhoodRepository = new Repository<Neighborhood>(_context)); }
        }
        public IRepository<Notification> NotificationRepository
        {
            get { return _NotificationRepository ?? (_NotificationRepository = new Repository<Notification>(_context)); }
        }
        public IRepository<Offer> OfferRepository
        {
            get { return _OfferRepository ?? (_OfferRepository = new Repository<Offer>(_context)); }
        }
        public IRepository<Region> RegionRepository
        {
            get { return _RegionRepository ?? (_RegionRepository = new Repository<Region>(_context)); }
        }
        public IRepository<ShopDal> ShopDalRepository
        {
            get { return _ShopDalRepository ?? (_ShopDalRepository = new Repository<ShopDal>(_context)); }
        }
        public IRepository<State> StateRepository
        {
            get { return _StateRepository ?? (_StateRepository = new Repository<State>(_context)); }
        }



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
