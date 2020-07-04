using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    /// Input cities for Nawafiz guide 
    /// </summary>
    public class InputGuideCityDto
    {
        /// <summary>
        /// Id required for edit not for insert
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// City sort 
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// City name in arabic
        /// </summary>
        public string ArabicCityName { set; get; }
        /// <summary>
        /// City name in english
        /// </summary>
        public string EnglishCityName { set; get; }

    }
}
