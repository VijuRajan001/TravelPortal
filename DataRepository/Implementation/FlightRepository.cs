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
    public class FlightRepository: Repository<FlightInfo>,IFlightRepository
    {

        public FlightRepository(TravDeskDbcontext context) : base(context)
        {


        }
      
        public void AddOnwardFlightOptions(List<FlightInfo> FlightItems)
        {

            TravDeskDbcontext.FlightInfo.AddRange(FlightItems);
           
            
        }



        public void AddReturnFlightOptions(List<FlightInfo> FlightItems)
        {
            TravDeskDbcontext.FlightInfo.AddRange(FlightItems);
        }

        public List<FlightInfo> GetFlightsForRequest(int id)
        {
            List<FlightInfo> FlightInfo = new List<FlightInfo>();
            FlightInfo = TravDeskDbcontext.FlightInfo.Where(f => f.RequestInfoId == id).ToList();

            return FlightInfo;
        }

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }
    }
}
