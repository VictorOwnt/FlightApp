using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public class PassengerProduct
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
