using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Favourite:IEntityBase
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        private ICollection<SubCategoryDal> _SubCategoryDals;
        public ICollection<SubCategoryDal> SubCategoryDals
        {
            get { return _SubCategoryDals ?? (_SubCategoryDals = new List<SubCategoryDal>()); }
            set { _SubCategoryDals = value; }
        }

        private ICollection<User> _Users;
        public ICollection<User> Users
        {
            get { return _Users ?? (_Users = new List<User>()); }
            set { _Users = value; }
        }
       
    }
}
