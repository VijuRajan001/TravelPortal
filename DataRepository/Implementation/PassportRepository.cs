using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using DataAccessRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessRepository.Implementation
{
    public class PassportRepository : Repository<PassportInfo>, IPassportRepository
    {
        
        public PassportRepository(TravDeskDbcontext context) : base(context)
        {
            

        }
        

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }

       

        public PassportInfo GetPassportDetails(int requestId)
        {
             
             
            return TravDeskDbcontext.PassportInfo
                .Where(f => f.RequestInfoId == requestId)
                .DefaultIfEmpty(new PassportInfo())
                .Single(); 
        }
    }
}
