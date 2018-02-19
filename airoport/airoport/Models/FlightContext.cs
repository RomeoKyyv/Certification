using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace airoport.Models
{
    public class FlightContext:DbContext
    {
        public DbSet<Flight> Flights { get; set; }
    }
}