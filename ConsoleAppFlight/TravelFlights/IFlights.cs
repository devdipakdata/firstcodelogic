using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelFlights
{
    /// <summary>
    /// IFlights Filter 
    /// </summary>
    public interface IFlights
    {
        /// <summary>
        /// Filters based on flight
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        IEnumerable<Flight> Filters(IEnumerable<Flight> flights);

    }
}
