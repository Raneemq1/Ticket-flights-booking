using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace TicketFlightsBooking.model
{
    public class BookSystem : MainSystem<Book>
    {
        private static BookSystem instance = null;
        private BookSystem() { }

        public static BookSystem Instance
        {
            get
            {
                return instance ??= new BookSystem();
            }
        }
        public IEnumerable<Book> ViewBooksForCertainPassenger(Passenger passenger)
        {
            return items.Where(book => book.Passenger.Name.Equals(passenger.Name)).ToList();
        }

        public IEnumerable<Book> GetBooksWithFlightId(string id)
        {
            return items.Where(book => book.Flight.FlightId == id).ToList();
        }

        public IEnumerable<Book> GetBooksWithPrice(double price)
        {
            return items.Where(book => book.Flight.FlightPrice <= price).ToList();
        }

        public IEnumerable<Book> GetBooksWithDestinationCountry(string country)
        {
            return items.Where(book => book.Flight.DestinationCountry == country).ToList();
        }

        public IEnumerable<Book> GetBooksWithDepartureCountry(string country)
        {
            return items.Where(book => book.Flight.DepartureCountry == country).ToList();
        }

        public IEnumerable<Book> GetBooksWithPassengerName(string name)
        {
            return items.Where(book => book.Passenger.Name == name).ToList();
        }

        public bool RemoveBookByFlightId(string id, Passenger passenger)
        {
            if (items.Remove(items.FirstOrDefault(book => book.Flight.FlightId == id && book.Passenger.Name == passenger.Name))) return true;
            return false;
        }

    }
}
