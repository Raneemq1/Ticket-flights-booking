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

        public override string ToString()
        {
            return $"Passenger Info:\nPassenger Name:{Passenger.Name}\t Phone:{Passenger.PhoneNumber}\n" +
                $"Booked Flight Information\n{Flight.ToString()}";
        }
    }
}
