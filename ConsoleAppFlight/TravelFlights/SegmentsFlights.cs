using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelFlights
{
    /// <summary>
    /// Have a segment with an arrival date before the departure date.
    /// </summary>
    public class SegmentsFlights : IFlights
    {
        public IEnumerable<Flight> Filters(IEnumerable<Flight> flights)
        {
            if (flights == null)
            {
                throw new ArgumentNullException("No flights found");
            }
            return flights.Where(flight => flight.Segments.Any(s => s.ArrivalDate < s.DepartureDate));
        }
    }
}
