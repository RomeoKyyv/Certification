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

    }
}