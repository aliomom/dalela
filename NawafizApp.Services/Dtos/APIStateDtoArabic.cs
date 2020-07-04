using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    /// state name in arabic language and its id
    /// </summary>
  public  class APIStateDtoArabic
    {/// <summary>
    /// the id of state
    /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// the arabic name 
        /// </summary>
        public string ArabicName { set; get; }
    }
}
