using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class FilterDto
    {
        public int subcatId { set; get; }
        public int maincat { set; get; }
        public int shopDalId { set; get; }
        public string shopDalName { set; get; }
    
    }
}
