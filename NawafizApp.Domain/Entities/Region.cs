using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Region :IEntityBase
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public virtual State State { set; get; }
        public int StateId { set; get; }
        private ICollection<Neighborhood> _Neighborhoods;
        public ICollection<Neighborhood> Neighborhoods
        {
            get { return _Neighborhoods ?? (_Neighborhoods = new List<Neighborhood>()); }
            set { _Neighborhoods = value; }
        }
    }
}
