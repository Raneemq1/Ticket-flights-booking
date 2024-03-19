using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlightsBooking.model;

namespace TicketFlightsBooking.service
{
    public class CSVReader
    {
        public CSVReader() { }

        public void GetFlightsData(string filePath)
        {
            FlightSystem system =FlightSystem.Instance;
            //check file existance 
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Invalid path");
            }
            //read file
            string[] lines = File.ReadAllLines(filePath);
            //skip headings line
            lines = lines.Skip(1).ToArray();
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                Flight flight = CreateFlightObject(fields);
                system.AddItem(flight);
            }

            
           
        }

        public Flight CreateFlightObject(string[] fields)
        {
            int i = 0;
            string id = fields[i++];
            double price = double.Parse(fields[i++]);
            string departureCountry = fields[i++];
            string destinationCountry = fields[i++];
            string departureDate = fields[i++];
            string departureAirport = fields[i++];
            string arrivalAirport = fields[i++];
            FlightClass type = StringToEnum(fields[i++]);

            Flight flight = new Flight(id, price, departureCountry, destinationCountry, departureDate, departureAirport, arrivalAirport, type);
            return flight;
        }
        public FlightClass StringToEnum(string str)
        {
            str = char.ToUpper(str[0]) + str.Substring(1);


            if (str == "Economy")
            {
                return FlightClass.Economy;
            }
            else if (str == "Busniess")
            {
                return FlightClass.Busniess;
            }
            else
            {
                return FlightClass.First;
            }
        }
    }
}
