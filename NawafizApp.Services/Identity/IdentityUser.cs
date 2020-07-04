using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NawafizApp.Services.Identity
{
    public class IdentityUser : IUser<Guid>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid();
        }

        public IdentityUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
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
        public int? Numberofpictures { get; set; }
        public bool? AddOffers { get; set; }
        public bool? Addnotifications { get; set; }
        public bool? Addbranches { get; set; }
        public int? NumberOfImagesAddedToranches { get; set; }
        public int? numOfBranches { set; get; }
        public bool? AddCustomeNotifications { set; get; }
        public bool hasToken { set; get; }
        public int shopId { set; get; }
        //public byte[] UserPhoto { get; set; } 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser,Guid> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}