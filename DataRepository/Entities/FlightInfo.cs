using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessRepository.Entities
{
    public class FlightInfo
    {
        public int Id { get; set; }
        public string FlightItemId {get;set;}
        public string FlightName { get; set; }
        public string FlightTo { get; set; }
        public string FlightFrom { get; set; }
        public double FlightCost { get; set; }
        public string FlightDirection { get; set; }
        public int RequestInfoId { get; set; }
        public RequestInfo RequestInfo { get; set; }
    }
}
