using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
   public class DeviceToken :IEntityBase
    {
        public int Id { set; get; }
        public string DeviceId { set; get; }
        public virtual User User { set; get; }
        public Guid UserId { set; get; }
    }
}
