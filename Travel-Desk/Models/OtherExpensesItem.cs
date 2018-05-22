using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelDesk.Models
{
    public class OtherExpensesItem
    {
        public DateTime Date { get; set; }
        public string NatureofExpense { get; set; }
        public double Currency { get; set; }
        public double AmountSpent { get; set; }
        public int Eligibility { get; set; }
        public Boolean SupportbyVoucher { get; set; }
        public double Total { get; set; }
        public int ReimbursementInfoId { get; set; }

    }
}
