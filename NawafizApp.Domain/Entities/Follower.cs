using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
 public class Follower:IEntityBase
    {
        public int Id { set; get; }
        public virtual User User { set; get; }
        private ICollection<ShopDal> _ShopDals;
        public ICollection<ShopDal> ShopDals
        {
            get { return _ShopDals ?? (_ShopDals = new List<ShopDal>()); }
            set { _ShopDals = value; }
        }
    }
}
