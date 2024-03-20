using CsvHelper;
using System;
using TicketFlightsBooking.model;
using TicketFlightsBooking.service;
using TicketFlightsBooking.utils;

namespace TicketAirportBooking
{
    public class Program
    {
        static void Main(string[] args)
        {

            MainMenu();
        }


        static void MainMenu()
        {
            Console.Clear();
            string? input;
            Console.WriteLine("Airport Flight Boooking Continue as");
            Console.WriteLine("1-Passenger\n2-Manager\n3-Exit");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1": { PassengerMenu(); break; }
                    case "2": { ManagerMenu(); break; }
                    case "3": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid input"); break;
                }
                input = Console.ReadLine();
            }

        }
        static void PassengerMenu()
        {
            Console.Clear();
            string? input;
            Console.WriteLine("1-Book a Flight\n2-Search a flight\n" +
                "3-Manage Booking\n4-Main Menu\n5-Exit");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1": { break; }
                    case "2": { break; }
                    case "3": { break; }
                    case "4": { MainMenu(); break; }
                    case "5": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid input"); break;
                }

                input = Console.ReadLine();
            }
        }
        static void ManagerMenu()
        {
            Console.Clear();
            string? input;
            Console.WriteLine("1-Upload data\n2-Filter Booking\n3-Main Menu\n4-Exit");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1":
                        {
                            FlightSystem system = FlightSystem.Instance;

                            try
                            {
                                var csvReader = new CSVReader<FlightSystem, Flight>(system, "AddFlight");
                                csvReader.UploadFlightsData(SystemData.filePath);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Environment.Exit(0);
                            }
                            break;
                        }
                    case "2": { break; }
                    case "3": { MainMenu(); break; }
                    case "4": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid number"); break;
                }

                input = Console.ReadLine();
            }

        }
    }
}