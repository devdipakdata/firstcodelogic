using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelFlights;

namespace ConsoleAppFlight
{
    class Program
    {
        static void Main(string[] args)
        {

            var MainFilters = new[]
            {
                new
                {
                    FilterData = "Flight departing before the current date/time",
                    Filter = (IFlights)new Departbefore(DateTime.Now),
                },
                new
                {
                    FilterData = "Flights:Have a segment with an arrival date before the departure date",
                    Filter = (IFlights)new SegmentsFlights(),
                },
                new
                {
                    FilterData = "Flights: Spend more than 2 hours on the ground",
                    Filter = (IFlights)new SpendsMoreTime(TimeSpan.FromHours(2)),
                },
            };

            var alldataFlights = new FlightBuilder().GetFlights();

            foreach (var mfilter in MainFilters)
            {
                var filteredFlightData = mfilter.Filter.Filters(alldataFlights).ToList();
                
                Console.WriteLine("*---------Data realted to Flight--*");
                Console.WriteLine("\n\t\r");
                Console.WriteLine(mfilter.FilterData + ":");
          
                foreach (var item in filteredFlightData)
                {
                    Console.WriteLine(string.Join(", ", item.Segments.Select(f => f.DepartureDate + "-----" + f.ArrivalDate)));
                }
                Console.WriteLine("\n\t\r");
            }
            Console.ReadLine();
            

        }
    }
}
