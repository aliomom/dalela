using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    ///Main category object
    /// </summary>
    /// 
    public class MainCategoryDtoAPI
    {
        /// <summary>
        ///id of Main Category
        /// </summary>
        /// 
        public int MainCatId { set; get; }
        /// <summary>
        ///Arabic name 
        /// </summary>
        /// 
        public string ArabicName { set; get; }
        /// <summary>
        ///arabic icon base64String
        /// </summary>
        /// 
        public string Arabicicon { set; get; }
    }
}
