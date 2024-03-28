using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace TicketFlightsBooking.model
{
    public class FlightSystem : MainSystem<Flight>
    {
        private static FlightSystem instance = null;

        private FlightSystem() { }
        public static FlightSystem Instance
        {
            get
            {
                 return instance ??= new FlightSystem();   
            }
        }
        
        public IEnumerable<Flight> GetFlightsWithDestinationCountry(string country)
        {
            return items.Where(flight => flight.DestinationCountry.ToLower() == country.ToLower()).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithDepartureCountry(string country)
        {
            return items.Where(flight => flight.DepartureCountry.ToLower() == country.ToLower()).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithArrivalAirport(string name)
        {
            return items.Where(flight => flight.ArrivalAirport.ToLower() == name.ToLower()).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithDepartureAirport(string name)
        {
            return items.Where(flight => flight.DepartureAirport.ToLower() == name.ToLower()).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithPrice(double price)
        {
            return items.Where(flight => flight.FlightPrice <= price).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithClassType(FlightClass type)
        {
            return items.Where(flight => flight.FlightType == type).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithDepartureDate(string date)
        {
            return items.Where(flight => flight.DepartureDate.Contains(date)).ToList();
        }

        public Flight GetFlightWithId(string id)
        {
            return items.FirstOrDefault(flight => flight.FlightId == id);
        }
       

    }
}
