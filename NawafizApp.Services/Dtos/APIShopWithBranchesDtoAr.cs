using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    ///a Shop Object 
    /// </summary>
    /// 
    public class APIShopWithBranchesDtoAr
    {
        public int ShopId { set; get; }
        public string ShopName { set; get; }
        public bool hasBarnches { set; get; }
        public int SubCategoryId { set; get; }
        public string SubCategoryName { set; get; }
        public int MainCategoryId { set; get; }
        public string MainCategoryName { set; get; }
        public string stateName { set; get; } 
        public string RegionName { set; get; }
        public string NeighborhoodName { set; get; }
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
        public TimeSpan EndActiveTime { set; get; }

        public List<APIBranchesForShop> Branches { set; get; }

        public List<APIGalleryphotoForBranchDto> photos { set; get; }
        public List<APIBreaksForBranchDto> breaks { set; get; }





    }
}
