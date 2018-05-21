using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp2;
using System.Globalization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<FlightDetails> lst = new List<FlightDetails>();
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                //Path given for the provider files.
                System.IO.TextReader readFile = new StreamReader(@"Provider1.txt");
                System.IO.TextReader readFile2 = new StreamReader(@"Provider2.txt");
                System.IO.TextReader readFile3 = new StreamReader(@"Provider3.txt");
                String strContinue;
                
                //reading and parsing first file
                var csv = new CsvReader(readFile);
                string format = "M/dd/yyyy H:mm:ss";
                
                csv.Configuration.Delimiter = ",";
                                 
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var origin = csv.GetField<string>(0);
                    string departTime = csv.GetField<string>(1);
                    DateTime departureTime;
                    if (!DateTime.TryParseExact(departTime, format, provider, System.Globalization.DateTimeStyles.None, out departureTime))
                   
                    {
                        // If TryParseExact Failed
                        Console.WriteLine("Failed to Parse Date");
                    }
                    var destination  = csv.GetField<string>(2);
                    var destTime = csv.GetField<string>(3);
                    DateTime destinationTime;
                    if (!DateTime.TryParseExact(destTime, format, provider, System.Globalization.DateTimeStyles.None, out destinationTime))

                    {
                        // If TryParseExact Failed
                        Console.WriteLine("Failed to Parse Date");
                    }
                    var price = csv.GetField<string>(4);
                   
                    var doublePrice = Convert.ToDouble(price.Substring(1));
                                    
                    lst.Add(new FlightDetails(origin, departureTime, destination, destinationTime, doublePrice));
                    
                }
                readFile.Close();

                //reading and parsing second file
                var csv2 = new CsvReader(readFile2);
                string format2 = "M-dd-yyyy H:mm:ss";
                csv2.Configuration.Delimiter = ",";
                csv2.Read();
                csv2.ReadHeader();
                while (csv2.Read())
                {
                    var origin = csv2.GetField<string>(0);
                    string departTime = csv2.GetField<string>(1);
                    DateTime departureTime;
                    if (!DateTime.TryParseExact(departTime, format2, provider, System.Globalization.DateTimeStyles.None, out departureTime))

                    {
                        // If TryParseExact Failed
                        Console.WriteLine("Failed to Parse Date");
                    }
                    var destination = csv2.GetField<string>(2);
                    var destTime = csv2.GetField<string>(3);
                    DateTime destinationTime;
                    if (!DateTime.TryParseExact(destTime, format2, provider, System.Globalization.DateTimeStyles.None, out destinationTime))

                    {
                        // If TryParseExact Failed
                        Console.WriteLine("Failed to Parse Date");
                    }
                    var price = csv2.GetField<string>(4);

                    var doublePrice = Convert.ToDouble(price.Substring(1));
                    lst.Add(new FlightDetails(origin, departureTime, destination, destinationTime, doublePrice));
                }
                readFile2.Close();

                //reading and parsing third file
                var csv3 = new CsvReader(readFile3);
                
                csv3.Configuration.Delimiter = "|";
                csv3.Read();
                csv3.ReadHeader();
                while (csv3.Read())
                {
                    var origin = csv3.GetField<string>(0);
                    string departTime = csv3.GetField<string>(1);
                    DateTime departureTime;
                    if (!DateTime.TryParseExact(departTime, format, provider, System.Globalization.DateTimeStyles.None, out departureTime))

                    {
                        // If TryParseExact Failed
                        Console.WriteLine("Failed to Parse Date");
                    }
                    var destination = csv3.GetField<string>(2);
                    var destiTime = csv3.GetField<string>(3);
                    DateTime  destinationTime;
                    
                    if (!DateTime.TryParseExact(destiTime, format, provider, System.Globalization.DateTimeStyles.None, out destinationTime))

                    {
                        // If TryParseExact Failed
                        Console.WriteLine("Failed to Parse Date");
                    }
                    var price = csv3.GetField<string>(4);

                    var doublePrice = Convert.ToDouble(price.Substring(1));
                    FlightDetails flightDetails = new FlightDetails(origin, departureTime, destination, destinationTime, doublePrice);
                    
                    lst.Add(flightDetails);
                }
                readFile3.Close();
                                                
                //Console.WriteLine(">>>>>>>>>>>>>>>>>>>SORTED&DISTICT<<<<<<<<<<<<<<<<<<<<<<");
                lst.Sort(new CompareProduct());
                //removing duplicates
                Int32 index = 0;
                while (index < lst.Count - 1)
                {
                    if (lst[index].Origin == (lst[index + 1].Origin) && lst[index].DepartureTime == (lst[index + 1].DepartureTime))
                        lst.RemoveAt(index);
                    else
                        index++;
                }
                Console.WriteLine("Origin-->Destination (DepartureTime-->DestinationTime) - Price");
                foreach (FlightDetails flightDetail in lst)
                {
                    Console.WriteLine(flightDetail.Origin + " --> " + flightDetail.Destination + " (" + flightDetail.DepartureTime + " --> " + flightDetail.DestinationTime + ")" + " - $" + flightDetail.Price);
                }
                do
                {
                    Console.WriteLine("Please Enter Origin");
                    String strOriginInput = Console.ReadLine();
                    Console.WriteLine("Please Enter Destination");
                    String strDestinationInput = Console.ReadLine();
                    Console.WriteLine("search Flights -o " + strOriginInput.ToUpper() + " -d " + strDestinationInput.ToUpper());

                    List<FlightDetails> searchedResults = new List<FlightDetails>();
                    foreach (FlightDetails flightDetail in lst)
                    {
                        if (flightDetail.Origin == strOriginInput.ToUpper() && flightDetail.Destination == strDestinationInput.ToUpper())
                        {
                            searchedResults.Add(flightDetail);
                        }
                    }

                    if (searchedResults.Count > 1)
                    {
                        Console.WriteLine("Origin-->Destination (DepartureTime-->DestinationTime) - Price");
                        foreach (FlightDetails flightDetail in searchedResults)
                        {
                            Console.WriteLine(flightDetail.Origin + " --> " + flightDetail.Destination + " (" + flightDetail.DepartureTime + " --> " + flightDetail.DestinationTime + ")" + " - $" + flightDetail.Price);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Flights for " + strOriginInput + "-->" + strDestinationInput);
                    }
                    Console.WriteLine(" >>>>> Please enter Y if you want to search more flights !!");
                     strContinue = Console.ReadLine();
                } while (strContinue.ToUpper() == "Y");

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
          
        }
    }
}
