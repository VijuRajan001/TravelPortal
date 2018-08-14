using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using DataAccessRepository.Interfaces;
using DataRepository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessRepository.Implementation
{
    public class RequestRepository : Repository<RequestInfo>, IRequestRepository
    {
        private readonly ConnectionStrings connectionStrings;

        public RequestRepository(IOptions<ConnectionStrings> options)
        {
            connectionStrings = options.Value;


        }
        public IEnumerable<RequestInfo> GetAllRequestsWithStatus(int status)
        {
            List<RequestInfo> RequestList = new List<RequestInfo>();
            try
            {
                string ConnectionPath = connectionStrings.DefaultConnection;
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    using (SqlCommand cmd = new SqlCommand("stp_GetAllRequests", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        sqlCon.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RequestInfo req = new RequestInfo();
                                req.Id = DataHelper.ConvertTo<int>(reader["RequestId"]);
                                req.EmployeeName = DataHelper.ConvertTo<string>(reader["EmployeeName"]);
                                req.RequestStatus = DataHelper.ConvertTo<string>(reader["RequestStatus"]);
                                req.TravelStart = DataHelper.ConvertTo<DateTime>(reader["TravelStart"]);
                                req.TravelReturn = DataHelper.ConvertTo<DateTime>(reader["TravelReturn"]);

                                
                            }
                        }

                        reader.Close();

                    }

                }



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return RequestList;


        }
    }
}
