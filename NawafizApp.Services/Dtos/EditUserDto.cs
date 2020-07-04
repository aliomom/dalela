using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class EditUserDto
    {
        public string username { get; set; }
        public string Password { get; set; }
        public Guid UserId { set; get; }
        public string CPassword { get; set; }
        public string FullName { get; set; }
        public int ShopId { set; get; }
        public string ShopName { set; get; }
        public string Role { set; get; }
        public bool Customize { set; get; }
        public int? Numberofpictures { get; set; }
        public bool AddOffers { get; set; }
        public bool Addnotifications { get; set; }
        public bool? AddbranchesGET { get; set; }
        public bool? AddOffersGET { get; set; }
        public bool? AddnotificationsGET { get; set; }
        public bool Addbranches { get; set; }
        public int? NumberOfImagesAddedToranches { get; set; }
        public int? numOfBranches { set; get; }
        public bool AddCustomeNotifications { set; get; }
        public bool? AddCustomeNotificationsGEt { set; get; }
    }
}
