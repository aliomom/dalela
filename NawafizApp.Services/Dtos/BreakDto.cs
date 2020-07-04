using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class BreakDto
    {
        public int Id { set; get; }
        public TimeSpan start { set; get; }
        public TimeSpan end { set; get; }
        public string sstr { set; get; }
        public string estr { set; get; }
        public int BranchId { set; get; }
        public string BranchName { set; get; }
    }
}
