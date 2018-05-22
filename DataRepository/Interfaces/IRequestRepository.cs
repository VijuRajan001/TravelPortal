using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessRepository.Interfaces
{
    public interface IRequestRepository :IRepository<RequestInfo>
    {
        IEnumerable<RequestInfo> GetAllRequestsWithStatus(int status);

    }
}
