using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using DataAccessRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace DataAccessRepository.Implementation
{
    public class RequestRepository : Repository<RequestInfo>, IRequestRepository
    {
        
        public RequestRepository(TravDeskDbcontext context) : base(context)
        {
            

        }
        public IEnumerable<RequestInfo> GetAllRequestsWithStatus(int status)
        {
            return TravDeskDbcontext.RequestInfo.Include(c => c.RequestStatus == "draft");
        }

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }
    }
}
