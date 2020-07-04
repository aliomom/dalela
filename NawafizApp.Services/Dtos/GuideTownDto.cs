using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    /// <summary>
    /// The town of the guide
    /// </summary>
    public class GuideTownDto
    {
        /// <summary>
        /// Town Id 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// City Id 
        /// </summary>
        public int CityId { set; get; }
        /// <summary>
        /// Town name 
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Coordinates of the town on the latitudes 
        /// </summary>
        public string Gps_Latitude { set; get; }
        /// <summary>
        /// Coordinates of the town on longitude
        /// </summary>
        public string Gps_Longitude { set; get; }


    }
}
