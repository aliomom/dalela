using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
    public class GuideTownDescription : IEntityBase
    {

        public int Id { get; set; }
        public int LanguageId { set; get; }
        public int TownId { set; get; }
        public string Name { set; get; }

        public virtual GuideTown GuideTown { set; get; }
        public virtual Language Language { set; get; }


    }
}
