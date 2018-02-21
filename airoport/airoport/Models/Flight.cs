using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace airoport.Models
{
    public class Flight

    {
        public int Id { set; get; }
        //Arival(departure) date and time, flight number, city/port of arrival(departure), airline, terminal, flight status
        //    (check-in, gate closed, arrived, departed at, unknown, canceled, expected at, delayed, in flight), gate
        public enum Ports { KIV, ZAP, LVI, VIN, DNP, HRS }
        public enum Airlines { MAU, LufGun, Vizz, KIY, Turk, BelA }
        public enum State { check_in, gate_closed, arrived, departed_at, unknown, canceled, expected_at, delayed, in_flight }
        public enum Term { A, B, C, D, E }


       DateTime? ArrivalTime { set; get; }
       public DateTime? DepTime { set; get; }
        public int FlightNum { set; get; }
        public string CityArriv { set; get; }
        public string CityDep { set; get; }
        public string Airline { set; get; }
        public string Status { set; get; }
        public string Terminal { set; get; }
        public string Gate { set; get; }



    }

}
