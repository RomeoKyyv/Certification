using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using airoport.Models;

namespace airoport.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        FlightContext db = new FlightContext();




        public ActionResult Index()
        {

            // получаем из бд все объекты Flight
            IEnumerable<Flight> flights = db.Flights;
            // передаем все объекты в динамическое свойство Flights в ViewBag
            ViewBag.Flights = flights;
            // возвращаем представление
            return View();

        }
        [HttpPost]
        public ActionResult Index(int? numparam,string stringparam)
        {
            var flights = db.Flights;
            var res = from b in db.Flights
                      where b.CityArriv.StartsWith(stringparam)
                      select b;
            if (numparam != null) {
                 res = from b in db.Flights
                          where b.CityArriv.StartsWith(stringparam) && b.FlightNum == numparam
                          select b;
            }
            Flight flight1 =new  Flight ();
            ViewBag.Flights = res;
            return View();
        }
        [HttpGet]
        public ActionResult Addf(int id)
        {
            ViewBag.FlightId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Addf(Flight flight)
        {
           // flight.Airline = "MAU";
            db.Flights.Add(flight);
            db.SaveChanges();
            return View();//"Flight is added ! Thank you!";
        }
        [HttpGet]
        public ActionResult Delf()
        {
            ViewBag.FlightId = 1;
            return View();
        }
        [HttpPost]
        public ActionResult Delf(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return View();// "Flight deleted!";
        }
        [HttpGet]
        public ActionResult Passengers (int FlightNum)
        {

            // получаем из бд все объекты Pass
            IEnumerable<Passenger> passengers = db.Passengers;
            var res = from b in db.Passengers
                      where b.FlightNum ==FlightNum
                      select b;

            // передаем все объекты в динамическое свойство Passengers в ViewBag
            ViewBag.Passengers = res;
            // возвращаем представление
            return View();
        }

    }
}