using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class Passenger
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Passenger(string id, string name, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
