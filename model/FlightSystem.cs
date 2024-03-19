using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class FlightSystem
    {
        private static FlightSystem? instance=null;
        private static List<Flight> flights = new();

        private FlightSystem() { }

        public static FlightSystem Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FlightSystem();
                }
                return instance;
            }
            
        }
        public void AddItem(Flight item)
        {
            flights.Add(item);
        }

        public ReadOnlyCollection<Flight> GetFlights()
        {
            return new ReadOnlyCollection<Flight>(flights);
        }
    }
}
