using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{ /// <summary>
  ///Offer object
  /// </summary>
  /// 
    public class APIOfferDtoAr
    {
        /// <summary>
        ///Offer Id which can be id for an Admin offer or for Client offer
        /// </summary>
        /// 
        public int id { set; get; }
        /// <summary>
        ///title of the Offer
        /// </summary>
        /// 
        public string title { set; get; }
        /// <summary>
        ///Offer photo represented in base64String || can be null
        /// </summary>
        /// 
        public string photo { set; get; }
        /// <summary>
        ///Offer details
        /// </summary>
        /// 
        public string details { set; get; }
        /// <summary>
        ///Start Date with format dd/mm/yyyy
        /// </summary>
        /// 
        public string StartDate { set; get; }
        /// <summary>
        ///end date  with format dd/mm/yyyy
        /// </summary>
        /// 
        public string endDate { set; get; }
        /// <summary>
        ///Time Of Publishing with format 00:00 PM||AM
        /// </summary>
        /// 
        public string Timeofpuplishing { set; get; }
        /// <summary>
        ///Date of Publishing with format dd/mm/yyyy
        /// </summary>
        /// 
        public string Dateofpuplishing { set; get; }
        /// <summary>
        ///id of the shop that puplished this offer >> this can be null if this offer is an Admin Offer
        /// </summary>
        /// 
        public int? BranchId { set; get; }
        /// <summary>
        ///Name of the shop that puplished this offer >> this can be null if this offer is an Admin Offer
        /// </summary>
        /// 
        public string ShopName { set; get; }


    }
}
