using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class RegionDto
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public int StateId { set; get; }
        public string stateAname { set; get; }
        public string stateFname { set; get; }
        public string statePname { set; get; }
        public string stateRname { set; get; }
        public string stateEname { set; get; }
    }
}
