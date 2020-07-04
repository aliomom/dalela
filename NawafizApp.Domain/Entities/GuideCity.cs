using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class GuideCity : IEntityBase
    {
       
        public int Id { get; set; }
        public int Sort { set; get; }
        public virtual ICollection<GuideCityDescription> GuideCityDescriptions { set; get; }
        public virtual ICollection<GuideTown> GuideTowns { set; get; }
     //   public virtual ICollection<Classify> Classifieds { set; get; }



    }
}
