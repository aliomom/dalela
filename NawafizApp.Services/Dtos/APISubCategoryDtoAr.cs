using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    ///subCategory Object {Arabic Language}
    /// </summary>
    /// 
    public class APISubCategoryDtoAr
    {
        /// <summary>
        ///id of Sub Category
        /// </summary>
        /// 
        public int SubCatId { set; get; }
        /// <summary>
        /// Name of Sub Category
        /// </summary>
        /// 
        public string SubCatName { set; get; }
        /// <summary>
        ///Sub Category icon represented in Base64String
        /// </summary>
        /// 
        public string SubCategoryIcon { set; get; }
        /// <summary>
        ///Name of Main Category that this SubCategory belongs to 
        /// </summary>
        /// 
        public string MainCategoryName { set; get; }
        /// <summary>
        ///Id  of Main Category that this SubCategory belongs to 
        /// </summary>
        /// 
        public int MainCatId { set; get; }
    }
}
