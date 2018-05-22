using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using DataAccessRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessRepository.Implementation
{
    public class ForexRepository : Repository<ForexInfo>, IForexRepository
    {
        
        public ForexRepository(TravDeskDbcontext context) : base(context)
        {
            

        }
        

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }




        public ForexInfo GetForexDetails(int requestId)
        {


            return TravDeskDbcontext.ForexInfo
                .Where(f => f.RequestInfoId == requestId)
                .DefaultIfEmpty(new ForexInfo())
                .Single();
        }

    }
}
