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

        public bool RemoveBookByFlightId(string id,Passenger passenger) {
            if(books.Remove(books.FirstOrDefault(book=>book.Flight.FlightId==id&&book.Passenger.Name==passenger.Name)))return true;
            return false;
        }

        public IEnumerable<Book>ViewBooksForCertainPassenger(Passenger passenger)
        {
            return books.Where(book=>book.Passenger.Name.Equals(passenger.Name)).ToList();
        }

        public IEnumerable<Book>GetBooksWithFlightId(string id)
        {
            return books.Where(book=>book.Flight.FlightId == id).ToList();  
        }

        public IEnumerable<Book> GetBooksWithPrice(double price)
        {
            return books.Where(book => book.Flight.FlightPrice <= price).ToList();
        }

        public IEnumerable<Book> GetBooksWithDestinationCountry(string country)
        {
            return books.Where(book => book.Flight.DestinationCountry == country).ToList();
        }

        public IEnumerable<Book> GetBooksWithDepartureCountry(string country)
        {
            return books.Where(book => book.Flight.DepartureCountry == country).ToList();
        }

        public IEnumerable<Book> GetBooksWithPassengerName(string name)
        {
            return books.Where(book => book.Passenger.Name == name).ToList();
        }
    }
}
