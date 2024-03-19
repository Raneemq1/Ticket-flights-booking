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

        public Flight(string flightId, double flightPrice, string departureCountry, string destinationCountry, string departureDate, string departureAirport, string arrivalAirport, FlightClass flightType)
        {
            FlightId = flightId;
            FlightPrice = flightPrice;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            FlightType = flightType;
        }



    }

    public enum FlightClass
    {
        Economy,
        Busniess,
        First
    }
}
