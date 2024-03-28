using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlightsBooking.model;
using TicketFlightsBooking.service;
using TicketFlightsBooking.utils;

namespace TicketFlightsBooking.view
{
    public class ManagerMenu
    {
        private static BookSystem bookSystem = BookSystem.Instance;
        private static FlightSystem flightSystem = FlightSystem.Instance;
        private static bool isUploaded = false;
        public ManagerMenu() { }

        public static void Display()
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
                            if (isUploaded)
                                Console.WriteLine("Data has already been uploaded.");
                            else
                            {
                                try
                                {
                                    var csvReader = new CSVReader<FlightSystem, Flight>(flightSystem, "AddItem");
                                    csvReader.UploadFileData(SystemData.filePath);
                                    isUploaded = true;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Environment.Exit(0);
                                }
                            }
                            break;
                        }
                    case "2": { FilterBooking(); break; }
                    case "3": { MainMenu.Display(); break; }
                    case "4": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid number"); break;
                }

                input = Console.ReadLine();
            }
        }

        static void FilterBooking()
        {
            string? input, searchedValue, value;
            double price;
            Console.Clear();
            Console.WriteLine("Filter booking by\n1-Flight ID\n2-Flight Price\n" +
                "3-Destenation Country\n4-Departure Country\n5-Passenger Name\n6-Back To Main Menu");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("Please input the FlightId to retrieve books associated with the same Id.");
                            searchedValue = Console.ReadLine();
                            ViewBooks(bookSystem.GetBooksWithFlightId(searchedValue));
                            Console.WriteLine("Write anything to return back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Please input the Price to retrieve books associated with the range of Price.");
                            double.TryParse(Console.ReadLine(), out price);
                            ViewBooks(bookSystem.GetBooksWithPrice(price));
                            Console.WriteLine("Write anything to return back");
                            value = Console.ReadLine();
                            break;
                        }


                    case "3":
                        {
                            Console.WriteLine("Please input the Destination Country to retrieve books associated with the same country.");
                            searchedValue = Console.ReadLine();
                            ViewBooks(bookSystem.GetBooksWithDestinationCountry(searchedValue));
                            Console.WriteLine("Write anything to return back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Please input the Departure Country to retrieve books associated with the same country.");
                            searchedValue = Console.ReadLine();
                            ViewBooks(bookSystem.GetBooksWithDepartureCountry(searchedValue));
                            Console.WriteLine("Write anything to return back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Please input the Passenger Name to retrieve books associated with the same passenger name.");
                            searchedValue = Console.ReadLine();
                            ViewBooks(bookSystem.GetBooksWithPassengerName(searchedValue));
                            Console.WriteLine("\nWrite anything to return back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "6": { Display(); break; }
                    default: break;

                }

                Console.Clear();
                Console.WriteLine("Filter booking by\n1-Flight ID\n2-Flight Price\n" +
                "3-Destenation Country\n4-Departure Country\n5-Passenger Name\n6-Back To Main Menu");
                input = Console.ReadLine();
            }
        }

        static void ViewBooks(IEnumerable<Book> books)
        {
            Console.Clear();
            if (!books.Any()) Console.WriteLine("There is no booking yet");

            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}