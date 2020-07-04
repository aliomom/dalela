using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
   public class MainCategoryDal:IEntityBase
    {
        public int Id { set; get; }
        public int? num { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public byte[] icon { set; get; }
        public byte[] iconEn { set; get; }
        public byte[] iconFr { set; get; }
        public byte[] iconPersian { set; get; }
        public byte[] iconRuss { set; get; }
        private ICollection<SubCategoryDal> _SubCategoryDals;
        public ICollection<SubCategoryDal> SubCategoryDals
        {
            get { return _SubCategoryDals ?? (_SubCategoryDals = new List<SubCategoryDal>()); }
            set { _SubCategoryDals = value; }
        }

    }
}
