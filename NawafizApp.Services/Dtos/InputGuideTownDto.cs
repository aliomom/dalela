using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    /// Input towns for Nawafiz guide 
    /// </summary>
    public class InputGuideTownDto
    {
        /// <summary>
        /// Id required for edit not for insert
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// required , City's Id where this town is located  
        /// </summary>
        public int CityId { set; get; }
        /// <summary>
        /// Town sort 
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// required , Town name in arabic  
        /// </summary>
        public string ArabicTownName { set; get; }
        /// <summary>
        /// required , Town name in english  
        /// </summary>
        public string EnglishTownName { set; get; }

    }
}
