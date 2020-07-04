using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class User
    {
        #region Fields
        private ICollection<Claim> _claims;
        private ICollection<ExternalLogin> _externalLogins;
        private ICollection<Role> _roles;
        
        #endregion

        #region Scalar Properties
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
      

        public int? Numberofpictures { get; set; }
        public bool? AddOffers { get; set; }
        public bool? Addnotifications { get; set; }
        public bool? Addbranches { get; set; }
        public int? NumberOfImagesAddedToranches { get; set; }
        public int? numOfBranches { set; get; }
        public bool? AddCustomeNotifications { set; get; }
        public bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FullName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool hasToken { set; get; }

        private ICollection<Favourite> _Favourites;
        public ICollection<Favourite> Favourites
        {
            get { return _Favourites ?? (_Favourites = new List<Favourite>()); }
            set { _Favourites = value; }
        }
        private ICollection<ShopDal> _ShopDals;
        public ICollection<ShopDal> ShopDals
        {
            get { return _ShopDals ?? (_ShopDals = new List<ShopDal>()); }
            set { _ShopDals = value; }
        }
        private ICollection<DeviceToken> _DeviceTokens;
        public ICollection<DeviceToken> DeviceTokens
        {
            get { return _DeviceTokens ?? (_DeviceTokens = new List<DeviceToken>()); }
            set { _DeviceTokens = value; }
        }

        private ICollection<Notification> _Notifications;
        public ICollection<Notification> Notifications
        {
            get { return _Notifications ?? (_Notifications = new List<Notification>()); }
            set { _Notifications = value; }
        }
        public virtual Follower Follower { set; get; }
      
        #endregion

        #region Navigation Properties
        public virtual ICollection<Claim> Claims
        {
            get { return _claims ?? (_claims = new List<Claim>()); }
            set { _claims = value; }
        }

        public virtual ICollection<ExternalLogin> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLogin>());
            }
            set { _externalLogins = value; }
        }

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }
        #endregion
    }
}
