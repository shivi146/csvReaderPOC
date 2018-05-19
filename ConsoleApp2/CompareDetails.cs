using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class CompareProduct : Comparer<FlightDetails>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(FlightDetails x, FlightDetails y)
        {
         
            if (x.Price.CompareTo(y.Price) != 0)
            {
                return x.Price.CompareTo(y.Price);
            }
            else if(x.DepartureTime.CompareTo(y.DepartureTime)!=0){
                return x.DepartureTime.CompareTo(y.DepartureTime);
            }
            else
            {
                return 0;
            }
        }
    }

}
