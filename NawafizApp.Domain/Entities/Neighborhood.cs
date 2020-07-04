using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Neighborhood :IEntityBase
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public virtual Region Region { set; get; }
        public int RegionId { set; get; }
        private ICollection<Branch> _Branchs;
        public ICollection<Branch> Branchs
        {
            get { return _Branchs ?? (_Branchs = new List<Branch>()); }
            set { _Branchs = value; }
        }
    }
}
