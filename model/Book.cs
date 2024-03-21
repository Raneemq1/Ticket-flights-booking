using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class Book
    {
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
       

        public Book(Passenger passenger, Flight flight)
        {
            Passenger = passenger;
            Flight = flight;
        }
    }
}
