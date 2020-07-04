using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
   public class Notification:IEntityBase
    {
        public int Id { set; get; }
        public Guid senderId { set; get; }
        public string title { set; get; }
        public string content { set; get; }
        public DateTime date { set; get; }
        public TimeSpan time { set; get; }
        public virtual User User { set; get; }
        public Guid RevieverId { set; get; }
    }
}
