using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class SubCategoryDal : IEntityBase
    {
        public int Id { set; get; }
        public int? num { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public byte[] iconEn { set; get; }
        public byte[] iconFr { set; get; }
        public byte[] iconPersian { set; get; }
        public byte[] iconRuss { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public byte[] icon { set; get; }
        public virtual MainCategoryDal MainCategoryDal { set; get; }
        public int MainCategoryDalId { set; get; }
        private ICollection<ShopDal> _ShopDals;
        public ICollection<ShopDal> ShopDals
        {
            get { return _ShopDals ?? (_ShopDals = new List<ShopDal>()); }
            set { _ShopDals = value; }
        }
        private ICollection<Favourite> _Favourites;
        public ICollection<Favourite> Favourites
        {
            get { return _Favourites ?? (_Favourites = new List<Favourite>()); }
            set { _Favourites = value; }
        }
    }
}
