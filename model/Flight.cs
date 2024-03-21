using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class Flight
    {
        private string flightId;
        private double flightPrice;
        private string departureCountry;
        private string departureDate;
        private string destinationCountry;
        private string departureAirport;
        private string arrivalAirport;
        private FlightClass flightType;
        public string FlightId
        {
            get => flightId;
            set
            {
                if (CheckStringValue(value, "FlightId")) flightId = value;
            }
        }
        public double FlightPrice
        {
            get => flightPrice;
            set
            {
                if (CheckPriceValue(value, "FlightPrice")) flightPrice = value;
            }
        }
        public string DepartureCountry
        {
            get => departureCountry;
            set
            {
                if (CheckStringValue(value, "DepartureCountry")) departureCountry = value;
            }
        }
        public string DestinationCountry
        {
            get => destinationCountry;
            set
            {
                if (CheckStringValue(value, "DestinationCountry")) destinationCountry = value;
            }
        }
        public string DepartureDate
        {
            get => departureDate;
            set
            {
                if (CheckDateValue(value, "DepartureDate")) departureDate = value;
            }
        }
        public string DepartureAirport
        {
            get => departureAirport;
            set
            {
                if (CheckStringValue(value, "DepartureAirport")) departureAirport = value;
            }
        }
        public string ArrivalAirport
        {
            get => arrivalAirport;
            set
            {
                if (CheckStringValue(value, "ArrivalAirport")) arrivalAirport = value;
            }
        }
        public FlightClass FlightType
        {
            get => flightType;
            set
            {
                if (CheckEnumValue(value, "FlightClass")) flightType = value;
            }
        }

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

        private bool CheckStringValue(string value, string propertyName)
        {
            if (value.Length == 0)
            {
                ExceptionHolder ex = new(propertyName, "Free Text", "Required");
                Console.WriteLine(ex.ToString());
                throw new Exception();
            }
            return true;
        }

        private bool CheckPriceValue(double value, string propertyName)
        {
            if (value < 0)
            {
                ExceptionHolder ex = new ExceptionHolder(propertyName, "Invalid Range", "Required");
                Console.WriteLine(ex.ToString());
                throw new Exception();
            }

            return true;
        }
        private bool CheckDateValue(string value, string propertyName)
        {
            string pattern = @"^\d{2}/\d{2}/\d{4}$";
            bool match = Regex.IsMatch(value, pattern);
            bool compareDates = CompareDates(value);

            if (match is false || compareDates is false)
            {
                ExceptionHolder ex = new ExceptionHolder(propertyName, "Date Time", "Required, Allowed Range (today → future)");
                Console.WriteLine(ex.ToString());
                throw new Exception();
            }
            return true;
        }
        private bool CompareDates(string date)
        {
            string todayDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
            DateTime currentDate = DateTime.ParseExact(todayDate, "dd/MM/yyyy", null);
            DateTime parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);

            if (parsedDate < currentDate) return false;
            return true;

        }
        private bool CheckEnumValue(FlightClass value, string propertyName)
        {
            if (value != FlightClass.Economy && value != FlightClass.Business && value != FlightClass.First)
            {
                ExceptionHolder ex = new ExceptionHolder(propertyName, "Invalid Class Type", "Required");
                Console.WriteLine(ex.ToString());
                throw new Exception();
            }
            return true;
        }
        public override string ToString()
        {
            return $"{FlightId}\t{FlightPrice:C}\t{DestinationCountry}\t" +
                $"{DepartureCountry}\t{DepartureAirport}\t{ArrivalAirport}\t{DepartureDate}";
        }

    }

    public enum FlightClass
    {
        Economy,
        Business,
        First
    }
}
