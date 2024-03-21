using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.view
{
    public class MainMenu
    {
        public MainMenu() { }

        public static void Display()
        {

            Console.Clear();
            string? input;
            Console.WriteLine("Airport Flight Boooking Continue as\n1-Passenger\n2-Manager\n3-Exit");
            input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1": { PassengerMenu.Display(); break; }
                    case "2": { ManagerMenu.Display(); break; }
                    case "3": { Environment.Exit(0); break; }
                    default: Console.WriteLine("Please enter a valid input"); break;
                }
                input = Console.ReadLine();
            }

        }
    }
}
