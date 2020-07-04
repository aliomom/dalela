using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class BranchDto
    {
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
        public TimeSpan EndActiveTime { set; get; }
        public string sstr { set; get; }
        public string estr { set; get; }
        public int NeighborhoodId { set; get; }
        public string NeighborhoodName { set; get; }
        public int stateId { set; get; }
        public int RegionId { set; get; }
        public string stateName { set; get; }
        public string RegionName { set; get; }
        public int? ShopDalId { set; get; }
        public string ShopDalName { set; get; }
    }
}
