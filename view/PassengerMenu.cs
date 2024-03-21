using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlightsBooking.model;

namespace TicketFlightsBooking.view
{
    public class PassengerMenu
    {
        private static bool loggedIn = false;
        private static Passenger samePassenger;
        private static BookSystem bookSystem = BookSystem.Instance;
        private static FlightSystem flightSystem = FlightSystem.Instance;
        public PassengerMenu() { }

        public static void Display()
        {
            Passenger passenger = loggedIn ? samePassenger : CreatePassenger();

            Console.Clear();
            string? input;
            Console.WriteLine("1-Book a Flight\n2-Search a flight\n" +
                "3-Manage Booking\n4-Main Menu\n5-Exit");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1": { if (passenger is not null) SearchToBook(passenger); break; }
                    case "2": { SearchFlights("passengermenu", passenger); break; }
                    case "3": { ManageBookingMenu(passenger); break; }
                    case "4": { loggedIn = false; MainMenu.Display(); break; }
                    case "5": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid input"); break;
                }

                input = Console.ReadLine();
            }
        }
        static void ManageBookingMenu(Passenger passenger)
        {

            Console.Clear();
            Console.WriteLine("1-View Personal Booking\n2-Remove Book\n3-Back");
            string? input, value, id;
            bool res;
            input = Console.ReadLine();
            while (true)
            {

                switch (input)
                {
                    case "1":
                        {
                            ViewBooks(bookSystem.ViewBooksForCertainPassenger(passenger));
                            Console.WriteLine("Type any thing to Back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter the FlightId to remove it ");
                            id = Console.ReadLine();
                            res = bookSystem.RemoveBookByFlightId(id, passenger);
                            if (res) Console.WriteLine("Sucessfully removed");
                            else Console.WriteLine("Issue with remove, try again");
                            Console.WriteLine("Type any thing to Back");
                            value = Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            Display();
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
                    case "3": { Display(); break; }
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
                            Flight flight = flightSystem.GetFlightWithId(id);
                            if (flight is not null)
                            {
                                Book book = new Book(passenger, flight);
                                bookSystem.AddItem(book);
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
                            if (baseMenuName is "passengermenu") Display(); else SearchToBook(passenger);
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

            var method = typeof(FlightSystem).GetMethod($"GetFlightsWith{methodName}") ?? throw new Exception("Invalid Method Name");
            object[] parameters = { value };
            IEnumerable<Flight> flights = (IEnumerable<Flight>)method.Invoke(flightSystem, parameters);
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
            if (!books.Any()) Console.WriteLine("There is no booking yet");

            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
