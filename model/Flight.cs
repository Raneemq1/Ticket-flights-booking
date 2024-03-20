using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class Flight
    {

        public string FlightId { get; set; }
        public double FlightPrice { get; set; }
        public string DepartureCountry { get; set; }
        public string DestinationCountry { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public FlightClass FlightType { get; set; }

        public Flight(string FlightId, double FlightPrice, string DepartureCountry, string DestinationCountry, string DepartureDate, string DepartureAirport, string ArrivalAirport, FlightClass FlightType)
        {
            this.FlightId = FlightId;
            this.FlightPrice = FlightPrice;
            this.DepartureCountry = DepartureCountry;
            this.DestinationCountry = DestinationCountry;
            this.DepartureDate = DepartureDate;
            this.DepartureAirport = DepartureAirport;
            this.ArrivalAirport = ArrivalAirport;
            this.FlightType = FlightType;
        }



    }

    public enum FlightClass
    {
        Economy,
        Business,
        First
    }
}
