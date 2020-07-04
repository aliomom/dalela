using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
   public class SubCategetoryOffers:IEntityBase
    {
        public int Id { set; get; }
        public int? num { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public MainCategoryOffers MainCategoryOffers { set; get; }
        public int MainCategoryOffersId { set; get; }
        private ICollection<Offer> _Offers;
        public ICollection<Offer> Offers
        {
            get { return _Offers ?? (_Offers = new List<Offer>()); }
            set { _Offers = value; }
        }
    }
}
