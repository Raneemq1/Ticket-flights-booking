using CsvHelper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicketFlightsBooking.model;

namespace TicketFlightsBooking.service
{
    public class CSVReader<TSystem, TObject>
        where TSystem : class
        where TObject : class
    {
        private TSystem system;
        private string nameOfAddMethod;
        public CSVReader(TSystem system, string methodName)
        {
            this.system = system ?? throw new Exception($"faild to create an instance");
            nameOfAddMethod = methodName;
            try
            {
                var AddMethod = typeof(TSystem).GetMethod(methodName) ?? throw new(("faild to call the method"));
            }
            catch
            {
                throw;
            }
        }

        public void UploadFileData(string filePath)
        {

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Invalid path");
                return;
            }
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                try
                {
                    var addMethod = typeof(TSystem).GetMethod(nameOfAddMethod);
                    IEnumerable<TObject> flights = csv.GetRecords<TObject>();
                    foreach (var flight in flights)
                    {
                        addMethod!.Invoke(system, new object[] { flight });
                    }

                    Console.WriteLine("Sucessfully upload data");
                }

                catch
                {
                    Console.WriteLine("Check file data");
                    return;

                }


            }
        }





    }
}
