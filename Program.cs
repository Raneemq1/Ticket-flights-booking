using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TicketFlightsBooking.model;
using TicketFlightsBooking.service;
using TicketFlightsBooking.utils;

namespace TicketAirportBooking
{
    public class Program
    {
        static bool loggedIn = false;
        static Passenger samePassenger;
        static void Main(string[] args)
        {
        
            MainMenu();
        }


        static void MainMenu()
        {
            loggedIn = false;
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
            Passenger passenger=!loggedIn?CreatePassenger():samePassenger;
            
            Console.Clear();
            string? input;
            Console.WriteLine("1-Book a Flight\n2-Search a flight\n" +
                "3-Manage Booking\n4-Main Menu\n5-Exit");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1": { if(passenger is not null)SearchToBook(passenger); break; }
                    case "2": { SearchFlights("passengermenu", passenger); break; }
                    case "3": { ManageBookingMenu(passenger); break; }
                    case "4": { MainMenu(); break; }
                    case "5": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid input"); break;
                }

                input = Console.ReadLine();
            }
        }

        static void ManageBookingMenu(Passenger passenger)
        {
            FlightSystem system = FlightSystem.Instance;
            Console.Clear();
            Console.WriteLine("1-View Personal Booking\n2-Remove Book\n3-Back");
            string? input,value,id;
            bool res;
            input = Console.ReadLine();
            while (true)
            {

                switch (input)
                {
                    case "1":
                        {
                            ViewBooks(system.ViewBooksForCertainPassenger(passenger));
                            Console.WriteLine("Type any thing to Back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter the FlightId to remove it ");
                            id = Console.ReadLine();
                            res=system.RemoveBookByFlightId(id,passenger);
                            if(res) Console.WriteLine("Sucessfully removed");
                            else Console.WriteLine("Issue with remove, try again");
                            Console.WriteLine("Type any thing to Back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            PassengerMenu();
                            break;
                        }
                    default: break;
                }
                Console.Clear();
                Console.WriteLine("1-View Personal Booking\n2-Remove Book\n3-Back");
                input = Console.ReadLine();
            }
        }
        static Passenger CreatePassenger()
        {
            loggedIn = true;
            Console.Clear();
            string id, name, address, phone, input;
            Random random = new Random();
            id = random.Next(999999).ToString();
            Console.WriteLine("Enter your Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter your Address");
            address = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number");
            phone = Console.ReadLine();
            Passenger passenger = new Passenger(id, name, address, phone); ;
            Console.WriteLine("Sucessfully LoggedIn\n\nPress Any Key to continue");
            input = Console.ReadLine();
            samePassenger = passenger;
            return passenger;
        }

        static void SearchToBook(Passenger passenger)
        {

            Console.Clear();
            string? input;
            Console.WriteLine("1-Search to book a suitbal travel by using flightId\n2-Book a flight\n3-Main Menu");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1": { SearchFlights("bookflight", passenger); break; }
                    case "2": { BookFlight(passenger); break; }
                    case "3": { PassengerMenu(); break; }
                    default: break;
                }
                Console.Clear();
                Console.WriteLine("1-Search to book a suitbal travel by using flightId\n2-Book a flight\n3-MainMenu");
                input = Console.ReadLine();
            }

        }

        static void BookFlight(Passenger passenger)
        {
            Console.Clear();
            FlightSystem system = FlightSystem.Instance;
            string? input, id;
            Console.WriteLine("Want to book a flight y/n");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "y":
                        {
                            Console.WriteLine("Enter The ID of flight you want to book it");
                            id = Console.ReadLine();
                            Flight flight = system.GetFlightWithId(id);
                            if (flight is not null)
                            {
                                Book book = new Book(passenger, flight);
                                system.AddBook(book);
                                Console.WriteLine("Sucessfully Added");
                            }
                            else { Console.WriteLine("Try Again"); }
                            Console.WriteLine("Enter any thing to return back");
                            input = Console.ReadLine();
                            break;
                        }
                    case "n": SearchToBook(passenger); break;
                    default: Console.WriteLine("Please choose y/n only"); break;
                }
                Console.Clear();
                Console.WriteLine("Want to book a flight y/n");
                input = Console.ReadLine();
            }
        }
        static void SearchFlights(string baseMenuName, Passenger passenger)
        {
            Console.Clear();
            string? input, value;
            double priceValue;
            Console.WriteLine("Search for a flight by:\n1-Destination Country\n" +
                "2-Departure Country\n3-Arrival Airport\n4-Departure Airport\n" +
                "5-Price\n6-Departure Date\n7-Class Type\n\n8-Back To Main Menue");
            input = Console.ReadLine();

            while (true)
            {
                switch (input)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Destination Country");
                            value = Console.ReadLine();
                            try { callMethod("DestinationCountry", value); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Departure Country");
                            value = Console.ReadLine();
                            try { callMethod("DepartureCountry", value); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;

                        }
                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Arrival Airport");
                            value = Console.ReadLine();
                            try { callMethod("ArrivalAirport", value); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Departure Airport");
                            value = Console.ReadLine();
                            try { callMethod("DepartureAirport", value); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Price Flight");
                            double.TryParse(Console.ReadLine(), out priceValue);
                            try { callMethod("Price", priceValue); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Departure Date");
                            value = Console.ReadLine();
                            try { callMethod("DepartureDate", value); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;
                        }
                    case "7":
                        {
                            Console.Clear();
                            Console.WriteLine("Write the Flight Class Type");
                            value = Console.ReadLine();
                            FlightClass type = StringToEnum(value);
                            try { callMethod("ClassType", type); }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); return; }
                            break;
                        }
                    case "8":
                        {
                            if (baseMenuName is "passengermenu") PassengerMenu(); else SearchToBook(passenger);
                            break;
                        }
                    default: { Console.WriteLine("Enter a valid choice"); break; }

                }
                Console.Clear();
                Console.WriteLine("Search for a flight by:\n1-DestinationCountry\n" +
                     "2-DepartureCountry\n3-ArrivalAirport\n4-DepartureAirport\n" +
                     "5-Price\n6-DepartureDate\n7-Class Type\n\n8-Back To Main Menue");
                input = Console.ReadLine();
            }

        }

        static void callMethod(string methodName, dynamic value)
        {
            FlightSystem system = FlightSystem.Instance;
            var method = typeof(FlightSystem).GetMethod($"GetFlightsWith{methodName}") ?? throw new Exception("Invalid Method Name");
            object[] parameters = { value };
            IEnumerable<Flight> flights = (IEnumerable<Flight>)method.Invoke(system, parameters);
            if (!flights.Any()) Console.WriteLine("No match data yet");
            else ViewFlights(flights);
            Console.WriteLine("Press any key to return to the menu");
            string newValue = Console.ReadLine();


        }
        static FlightClass StringToEnum(string value)
        {
            value = value.ToLower();
            if (value is "first")
            {
                return FlightClass.First;
            }
            else if (value is "business")
            {
                return FlightClass.Business;
            }
            else
            {
                return FlightClass.Economy;
            }

        }
        static void ViewFlights(IEnumerable<Flight> flights)
        {
            Console.WriteLine("FlightId\tFlightPrice\tDestinationCountry\tDepartureCountry\tDepartureAirport\tArrivalAirport\tDepartureDate");

            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }


        static void ViewBooks(IEnumerable<Book> books)
        {
            Console.Clear();
            if(!books.Any()) Console.WriteLine("There is no booking yet");

            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
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
                            catch (Exception ex)
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