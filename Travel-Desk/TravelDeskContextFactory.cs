using DataAccessRepository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataRepository.Base
{
    public class TravelDeskContextFactory: IDesignTimeDbContextFactory<TravDeskDbcontext>
    {


        public TravDeskDbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<TravDeskDbcontext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new TravDeskDbcontext(optionsBuilder.Options);
        }
    
    }
}
