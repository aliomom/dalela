using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class NeihborhoodDto
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public int RegionId { set; get; }
        public string regionAName { set; get; }
        public string regionEName { set; get; }
        public string regionFName { set; get; }
        public string regionPName { set; get; }
        public string regionRName { set; get; }
        public string statename { set; get; }
        public int stateId { set; get; }
    }
}
