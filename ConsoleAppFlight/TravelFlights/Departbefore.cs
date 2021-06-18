using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelFlights
{
    /// <summary>
    /// Depart before the current date/time.
    /// </summary>
    public class Departbefore : IFlights
    {
        private readonly DateTime _depBefore;

        private readonly String testdata;
        public Departbefore(DateTime depBefore )
        {
            _depBefore = depBefore;
        }

        /// <summary>
        /// Filters condition 
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> Filters(IEnumerable<Flight> flights)
        {
            if (flights == null)
            {
                throw new ArgumentNullException("flights not found");
            }
            return flights.Where(flight => flight.Segments.Any()).
                Where(flight => flight.Segments[0].DepartureDate < _depBefore);
        }
    }
}
