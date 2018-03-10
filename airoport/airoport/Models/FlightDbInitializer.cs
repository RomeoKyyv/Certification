using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace airoport.Models
{
    public class FlightDbInitializer: DropCreateDatabaseAlways<FlightContext>
    {
        
        protected override void Seed(FlightContext db)
        {
            
            {
                string [] Fnames = new string[] { "Anna", "Bill", "Danial", "Ema", "Frederick", "Gregory", "Kray", "Melisa", "Lisa", "Nataly", "Nick" };
                string[] Snames = { "Prins", "Nuss", "Rabalais", "Kitamura", "Dagenhart", "Gretchen", "Dunkerson", "Juliette", "Haugland", "Wendell" };

                 int tmp = 0;
                string prt;
                Random rndobj = new Random();
                for (int i = 0; i < 10; i++)
                {
                    
                    Flight flight = new Flight();
                    FlighPrice FlPr = new FlighPrice();

                    var year = rndobj.Next(2018, 2018);
                    var month = rndobj.Next(1, 13);
                    var days = rndobj.Next(1, DateTime.DaysInMonth(year, month) + 1);

                    var rndtime = new DateTime(year, month, days,
                       rndobj.Next(0, 24), rndobj.Next(0, 60), rndobj.Next(0, 60), rndobj.Next(0, 1000));

                    flight.DepTime=rndtime;
                    //rndtime = rndtime.AddHours(rndobj.Next(0, 12));
                    //rndobj.Next(0, 60);
                    //rndtime = rndtime.AddMinutes(rndobj.Next(0, 60));
                    //flights[i].SetArrivalTime(rndtime);


                    tmp = rndobj.Next(5);

                    // generate fl Arr port
                    tmp = rndobj.Next(5);
                    prt = Enum.GetName(typeof(Flight.Ports), tmp);
                    flight.CityArriv =prt;

                    tmp = rndobj.Next(1000);
                    flight.FlightNum=tmp;

                    tmp = rndobj.Next(5);
                    prt = Enum.GetName(typeof(Flight.Ports), tmp);
                    flight.CityDep=prt;

                    tmp = rndobj.Next(6);
                    prt = Enum.GetName(typeof(Flight.Airlines), tmp);
                    flight.Airline=prt;

                    tmp = rndobj.Next(9);
                    prt = Enum.GetName(typeof(Flight.State), tmp);
                    flight.Status = prt;

                    tmp = rndobj.Next(5);
                    prt = Enum.GetName(typeof(Flight.Term), tmp);
                    flight.Terminal = prt;

                    tmp = rndobj.Next(4);
                    flight.Gate = tmp;

                    db.Flights.Add(flight);
                    // init FlPrice
                    tmp = rndobj.Next(100,500);
                    FlPr.PriceBis = tmp;
                    tmp = rndobj.Next(70, 300);
                    FlPr.PriceEco = tmp;

                    db.FlighPrises.Add(FlPr);

                    for (int j = 0; j < 3; j++)
                    {
                        Passenger Ps1 = new Passenger();
                        // init Passengers
                        Ps1.FlightNum = flight.FlightNum;
                        tmp = rndobj.Next(11);
                        Ps1.FirstName = Fnames[tmp];
                        tmp = rndobj.Next(9);

                        Ps1.SecondName = Snames[tmp];
                        
                        db.Passengers.Add(Ps1);

                    }
                }
            }

             base.Seed(db);
        }
    }
}