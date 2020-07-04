using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
   public class FollowerDto
    {
        public int Id { set; get; }
        public Guid UserId { set; get; }
        public string userName { set; get; }
        public List<int> shopdalids { set; get; }
        public List<string> shopdalnames { set; get; }
    }
}
