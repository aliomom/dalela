using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class GuideCityDescription : IEntityBase
    {

        public int Id { get; set; }
        public int LanguageId { set; get; }
        public int CityId { set; get; }
        public string Name { set; get; }

        public virtual GuideCity GuideCity { set; get; }
        public virtual Language Language { set; get; }


    }
}