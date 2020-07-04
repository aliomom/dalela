using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    public class FavouriteDto
    {
        public int Id { set; get; }
        public string ArabicName { set; get; }
        public string EngName { set; get; }
        public string FrenchName { set; get; }
        public string RussName { set; get; }
        public string PersianName { set; get; }
        public List<int> subCatIds { set; get; }
        public List<Guid> usersId { set; get; }
        public Guid userid { set; get; }   
        public List<string> subcatname { set; get; }

    }
}
