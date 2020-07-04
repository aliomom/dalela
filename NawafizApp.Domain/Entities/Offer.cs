using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Offer :IEntityBase
    {
        public int Id { set; get; }
        public string Atitle { set; get; }
        public string Etitle { set; get; }
        public string Ftitle { set; get; }
        public string Ptitle { set; get; }
        public string Rtitle { set; get; }
        public byte[] photo { set; get; }
        public byte[] photo1 { set; get; }
        public byte[] photo2 { set; get; }
        public byte[] photo3 { set; get; }
        public string Adetails { set; get; }
        public string Edetails { set; get; }
        public string Fdetails { set; get; }
        public string Pdetails { set; get; }
        public string Rdetails { set; get; }
        public string phon1 { set; get; }
        public string phon2 { set; get; }
        public string phon3 { set; get; }
        public string phon4 { set; get; }
        public string phon5 { set; get; }
        public string phon6 { set; get; }
        public string email { set; get; }
        public string faceLink { set; get; }
        public string instaLink { set; get; }
        public string Whatsphon { set; get; }
        public DateTime Start { set; get; }
        public DateTime end { set; get; }
        public TimeSpan Timeofpuplishing { set; get; }
        public DateTime Dateofpuplishing { set; get; }
        public virtual SubCategetoryOffers SubCategetoryOffers { set; get; }
        public int SubCategetoryOffersId { set; get; }
    }
}
