using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class Role
    {
        #region Fields
        private ICollection<User> _users;
        #endregion

        #region Scalar Properties
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public int Numberofpictures { get; set; }
        public int numOfBranches { set; get; }
        public bool AddCustomeNotifications { set; get; }
        public bool AddOffers { get; set; }
        public bool Addnotifications { get; set; }
        public bool Addbranches { get; set; }
        public int NumberOfImagesAddedToranches { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }
        #endregion
    }
}
