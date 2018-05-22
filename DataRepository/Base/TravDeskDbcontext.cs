using DataAccessRepository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System; 

namespace DataAccessRepository.Base
{
    public class TravDeskDbcontext : IdentityDbContext
    {

        public TravDeskDbcontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<FlightInfo> FlightInfo { get; set; }
        public DbSet<ForexInfo> ForexInfo { get; set; }
        public DbSet<HotelInfo> HotelInfo{ get; set; }
        public DbSet<PassportInfo> PassportInfo{ get; set; }
        public DbSet<RequestInfo> RequestInfo { get; set; }
        public DbSet<ReimbursementInfo> ReimbursementInfo { get; set; }
        public DbSet<FareInfo> FareInfo { get; set; }
        public DbSet<PerDiemInfo> PerDiemInfo { get; set; }
        public DbSet<BoardingLodgingInfo> BoardingLodgingInfo { get; set; }
        public DbSet<TravelExpensesWithVoucherInfo> TravelExpensesWithVoucherInfo { get; set; }
        public DbSet<TravelExpensesWithoutVoucherInfo> TravelExpensesWithoutVoucherInfo { get; set; }
        public DbSet<OtherExpensesInfo> OtherExpensesInfo { get; set; }
    }
}
