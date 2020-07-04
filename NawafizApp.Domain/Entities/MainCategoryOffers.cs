using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class MainCategoryOffers:IEntityBase
    {
        public int Id { set; get; }
        public int? num { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        private ICollection<SubCategetoryOffers> _SubCategetoryOfferss;
        public ICollection<SubCategetoryOffers> SubCategetoryOfferss
        {
            get { return _SubCategetoryOfferss ?? (_SubCategetoryOfferss = new List<SubCategetoryOffers>()); }
            set { _SubCategetoryOfferss = value; }
        }
    }
}
