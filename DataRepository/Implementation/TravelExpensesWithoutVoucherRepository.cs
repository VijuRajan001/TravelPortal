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
    public class TravelExpensesWithoutVoucherRepository : Repository<TravelExpensesWithoutVoucherInfo>, ITravelExpensesWithoutVoucherRepository
    {

        public TravelExpensesWithoutVoucherRepository(TravDeskDbcontext context) : base(context)
        {


        }



        public void AddTravelExpensesWithoutVoucherOptions(List<TravelExpensesWithoutVoucherInfo> travelExpensesWithoutVoucherItems)
        {
            TravDeskDbcontext.TravelExpensesWithoutVoucherInfo.AddRange(travelExpensesWithoutVoucherItems);
        }

        List<TravelExpensesWithoutVoucherInfo> ITravelExpensesWithoutVoucherRepository.GetTravelExpensesWithoutVoucherForRequest(int id)
        {
            List<TravelExpensesWithoutVoucherInfo> TravelExpensesWithoutVoucherInfo = new List<TravelExpensesWithoutVoucherInfo>();
            TravelExpensesWithoutVoucherInfo = TravDeskDbcontext.TravelExpensesWithoutVoucherInfo.Where(f => f.ReimbursementInfoId == id).ToList();

            return TravelExpensesWithoutVoucherInfo;
        }

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }
    }
}
