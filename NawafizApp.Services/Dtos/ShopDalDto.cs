using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class ShopDalDto
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
        public string facebookLink { set; get; }
        public string instaLink { set; get; }
        public string PersianinvesterName { set; get; }
        public int SubCategoryDalId { set; get; }
        public Guid? UserId { set; get; }
        public string username { set; get; }
        
        public List<int> BranchIds { set; get; }
        public string branchesname { set; get; }
    }
}
