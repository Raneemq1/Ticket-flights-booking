using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlightsBooking.model
{
    public class ExceptionHolder
    {
        public string ExceptionField { set; get; }
        public string ExceptionType { set; get; }
        public string ExcpetionConstrain { set; get; }

        public ExceptionHolder(string exceptionField, string exceptionType, string excpetionConstrain)
        {
            ExceptionField = exceptionField;
            ExceptionType = exceptionType;
            ExcpetionConstrain = excpetionConstrain;
        }

        public override string ToString()
        {
            return $"{ExceptionField}:\n\tType:{ExceptionType}\n\tConstraint:{ExcpetionConstrain}\n";
        }
    }
}
