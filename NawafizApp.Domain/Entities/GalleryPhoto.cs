using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
   public class GalleryPhoto:IEntityBase
    {
        public int Id { set; get; }
        public byte[] photo { set; get; }
        public virtual Branch Branch { set; get; }
        public int BranchId { set; get; }
    }
}
