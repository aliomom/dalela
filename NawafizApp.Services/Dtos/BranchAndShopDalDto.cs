using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
  public  class BranchAndShopDalDto
    {
        public int shopId { set; get; }
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
        public int SubCategoryDalId { set; get; }
        public string SubCategoryDalName { set; get; }
        public int mainCategoryId { set; get; }
        public string mainCategoryName { set; get; }

        public Guid? UserId { set; get; }
        public string userName { set; get; }
        public string rolename { set; get; }
        public int Id { set; get; }
        public string branchArabicName { set; get; }
        public string branchEnglishName { set; get; }
        public string branchFrenchName { set; get; }
        public string branchRussName { set; get; }
        public string branchPersianName { set; get; }
        public string facebookLink { set; get; }
        public string instaLink { set; get; }
        public string email1 { set; get; }
        public string email2 { set; get; }
        public string phone1 { set; get; }
        public string phone2 { set; get; }
        public string phone3 { set; get; }
        public decimal longtitude { set; get; }
        public decimal latitude { set; get; }
        public string outDays { set; get; }
        public TimeSpan StartActiveTime { set; get; }
        public string startstr { set; get; }
        public string endstr { set; get; }
        public TimeSpan EndActiveTime { set; get; }
        public int NeighborhoodId { set; get; }
        public string NeighborhoodName { set; get; }
        public int regionId { set; get; }
        public string regionName { set; get; }
        public int stateId { set; get; }
        public string stateName { set; get; }

    }
}
