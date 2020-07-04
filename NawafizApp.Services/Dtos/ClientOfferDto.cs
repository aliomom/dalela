using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class ClientOfferDto
    {
        public int Id { set; get; }
        public string title { set; get; }
        public byte[] photo { set; get; }
        public string details { set; get; }
        public DateTime Start { set; get; }
        public DateTime end { set; get; }
        public TimeSpan Timeofpuplishing { set; get; }
        public DateTime Dateofpuplishing { set; get; }
        public int BranchId { set; get; }
        public string BranchName { set; get; }
    }
}
