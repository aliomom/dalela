using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    ///offers sub category object
    /// </summary>
    /// 
    public class APIOffersSubCategiesDtoAr
    {
        public int id { set; get; }
        public string ArabicName { set; get; }
        public int NumOfOffers { set; get; }
        public bool isAdminOffer { set; get; }
    }
}
