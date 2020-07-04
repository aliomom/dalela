using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
   public class Branch:IEntityBase
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
        private ICollection<Break> _Breaks;
        public ICollection<Break> Breaks
        {
            get { return _Breaks ?? (_Breaks = new List<Break>()); }
            set { _Breaks = value; }
        }
        private ICollection<GalleryPhoto> _GalleryPhotos;

        public ICollection<GalleryPhoto> GalleryPhotos
        {
            get { return _GalleryPhotos ?? (_GalleryPhotos = new List<GalleryPhoto>()); }
            set { _GalleryPhotos = value; }
        }
        private ICollection<ClientOffer> _ClientOffers;
        public ICollection<ClientOffer> ClientOffers
        {
            get { return _ClientOffers ?? (_ClientOffers = new List<ClientOffer>()); }
            set { _ClientOffers = value; }
        }
        public virtual ShopDal ShopDal { set; get; }
        public int ShopDalId { set; get; }

        public virtual Neighborhood Neighborhood { set; get; }
        public int NeighborhoodId { set; get; }
    }
}
