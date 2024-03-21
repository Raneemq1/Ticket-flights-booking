using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class FlightSystem
    {
        private static FlightSystem? instance = null;
        private static List<Flight> flights = new();
        private static List<Book> books = new();

        private FlightSystem() { }

        public static FlightSystem Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new FlightSystem();
                }
                return instance;
            }

        }
        public void AddFlight(Flight item)
        {
            flights.Add(item);
        }

        public ReadOnlyCollection<Flight> GetFlights()
        {
            return new ReadOnlyCollection<Flight>(flights);
        }

        public IEnumerable<Flight> GetFlightsWithDestinationCountry(string country)
        {
            return flights.Where(flight => flight.DestinationCountry.ToLower() == country.ToLower()).ToList();
        }
        
        public IEnumerable<Flight> GetFlightsWithDepartureCountry(string country)
        {
            return flights.Where(flight => flight.DepartureCountry.ToLower() == country.ToLower()).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithArrivalAirport(string name)
        {
            return flights.Where(flight => flight.ArrivalAirport.ToLower() == name.ToLower()).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithDepartureAirport(string name)
        {
            return flights.Where(flight => flight.DepartureAirport.ToLower() == name.ToLower()).ToList();
        }
        
        public IEnumerable<Flight> GetFlightsWithPrice(double price)
        {
            return flights.Where(flight => flight.FlightPrice <= price).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithClassType(FlightClass type)
        {
            return flights.Where(flight => flight.FlightType == type).ToList();
        }

        public IEnumerable<Flight> GetFlightsWithDepartureDate(string date)
        {
            return flights.Where(flight => flight.DepartureDate.Contains(date)).ToList();
        }

        public Flight GetFlightWithId(string id)
        {
            return flights.FirstOrDefault(flight => flight.FlightId == id);
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }

      
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }
    }
}
