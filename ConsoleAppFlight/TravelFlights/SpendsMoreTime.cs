using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelFlights
{
    /// <summary>
    /// Spend more than 2 hours on the ground
    /// </summary>
    public class SpendsMoreTime : IFlights
    {
        private readonly TimeSpan _timeOnGround;

        public SpendsMoreTime(TimeSpan mTimeOnGround)
        {
            if (mTimeOnGround.TotalHours <= 0)
            {
                throw new ArgumentException("Time on ground must be a positive time", "time On Ground");
            }
            _timeOnGround = mTimeOnGround;
        }

        /// <summary>
        /// Filter condition  
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> Filters(IEnumerable<Flight> flights)
        {
            if (flights == null)
            {
                throw new ArgumentNullException("No flights found");
            }
            return flights.Where(FlightSpendMoreTimeOnGround);
        }
       

        private bool FlightSpendMoreTimeOnGround(Flight flight)
        {
            Segment pSegment = null;
            foreach (var segment in flight.Segments)
            {
                if (pSegment != null)
                {
                    if ((segment.DepartureDate - pSegment.ArrivalDate) > _timeOnGround)
                    {
                        return true;
                    }
                }

                pSegment = segment;
            }
            return false;
        }
    }
}
