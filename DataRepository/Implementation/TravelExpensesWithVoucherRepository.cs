using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using DataAccessRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessRepository.Implementation
{
    public class TravelExpensesWithVoucherRepository : Repository<TravelExpensesWithVoucherInfo>, ITravelExpensesWithVoucherRepository
    {

        public TravelExpensesWithVoucherRepository(TravDeskDbcontext context) : base(context)
        {


        }
      
        

        public void AddTravelExpensesWithVoucherOptions(List<TravelExpensesWithVoucherInfo> travelExpensesWithVoucherItems)
        {
            TravDeskDbcontext.TravelExpensesWithVoucherInfo.AddRange(travelExpensesWithVoucherItems);
        }

        List<TravelExpensesWithVoucherInfo> ITravelExpensesWithVoucherRepository.GetTravelExpensesWithVoucherForRequest(int id)
        {
            List<TravelExpensesWithVoucherInfo> TravelExpensesWithVoucherInfo = new List<TravelExpensesWithVoucherInfo>();
            TravelExpensesWithVoucherInfo = TravDeskDbcontext.TravelExpensesWithVoucherInfo.Where(f => f.ReimbursementInfoId == id).ToList();

            return TravelExpensesWithVoucherInfo;
        }

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }
    }
}
