using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class ShopDal : IEntityBase
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public string ArabicinvesterName { set; get; }
        public string EnginvesterName { set; get; }
        public string FrenchinvesterName { set; get; }
        public string RussinvesterName { set; get; }     
        public string PersianinvesterName { set; get; }
        private ICollection<Branch> _Branchs;
        public ICollection<Branch> Branchs
        {
            get { return _Branchs ?? (_Branchs = new List<Branch>()); }
            set { _Branchs = value; }
        }
        public virtual SubCategoryDal SubCategoryDal { set; get; }
        public int SubCategoryDalId { set; get; }
        public virtual User User { set; get; }
        public Guid? UserId { set; get; }
        private ICollection<Follower> _Followers;
        public ICollection<Follower> Followers
        {
            get { return _Followers ?? (_Followers = new List<Follower>()); }
            set { _Followers = value; }
        }
    }
}
