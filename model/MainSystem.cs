using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class MainSystem<T>
    {
        protected List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public IEnumerable<T> GetItems()
        {
            return items;
        }

    }
}
