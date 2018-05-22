using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDesk.Models
{
    public class RequestItem
    {
        public int RequestId { get; set; }
        public string Project_Code { get; set; }
        public string Country { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime Dob { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string RequestStatus { get; set; }
    }
}
