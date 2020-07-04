using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class GuideTown : IEntityBase
    {

        public int Id { get; set; }
        public int CityId { set; get; }
        public string Gps_Latitude { set; get; }
        public string Gps_Longitude { set; get; }
        public int Sort { set; get; }
        public virtual GuideCity GuideCity { set; get; }
        public virtual ICollection<GuideTownDescription> GuideTownDescriptions { set; get; }
        public virtual ICollection<GuideClassify> GuideClassifieds { set; get; } //


    }
}
