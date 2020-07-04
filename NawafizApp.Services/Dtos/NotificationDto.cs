using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
public    class NotificationDto
    {
        public int Id { set; get; }
        public Guid senderId { set; get; }
        public string title { set; get; }
        public string content { set; get; }
        public DateTime date { set; get; }
        public string strdate { set; get; }
        public TimeSpan time { set; get; }
        public string strtime { set; get; }
        public Guid RevieverId { set; get; }
        public int impid { set; get; }
    }
}
