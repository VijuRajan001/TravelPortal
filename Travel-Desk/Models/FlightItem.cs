using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDesk.Models
{
    public class FlightItem
    {
        public int Id { get; set; }
        public string FlightItemId { get; set; }
        public string FlightName { get; set; }
        public string FlightTo { get; set; }
        public string FlightFrom { get; set; }
        public double FlightCost { get; set; }
        public string FlightDirection { get; set; }
        public int RequestInfoId { get; set; }
        
    }
}
