using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    /// The city of the guide
    /// </summary>
    public class GuideCityDto
    {
        /// <summary>
        /// City Id 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// City name
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// List of towns that belong to this city
        /// </summary>
        public List<GuideTownDto> TownsDto { set; get; }

    }
}


