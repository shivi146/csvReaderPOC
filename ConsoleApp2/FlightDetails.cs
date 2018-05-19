using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class FlightDetails
    {
        private string origin;
        private DateTime departureTime;
        private string destination;
        private DateTime destinationTime;
        private double price;

        public string Origin { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public double Price { get; set; }

        public FlightDetails(string origin, DateTime departureTime, string destination, DateTime destinationTime, double price)
        {
            Origin = origin;
            DepartureTime = departureTime;
            Destination = destination;
            DestinationTime = destinationTime;
            Price = price;
        }


        



        public double CompareTo(FlightDetails other)
        {
                             
            // Compares Price,Departure time
            if (this.price.CompareTo(other.price) != 0)
            {
                return this.price.CompareTo(other.price);
            }
            if (this.departureTime.CompareTo(other.departureTime) != 0)
            {
                return this.departureTime.CompareTo(other.departureTime);
            }
            else
            {
                return 0d;
            }
        }
    }
}
