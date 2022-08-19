using EasyTicketsSolution.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTicketsSolution.Data.Data
{
    internal class EasyTicketsDbContextFactory : IDesignTimeDbContextFactory<EasyTickets_WebAppContext>
    {
        public EasyTickets_WebAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = (IConfigurationRoot)new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("EasyTicketsDb");
            var optionsBuilder = new DbContextOptionsBuilder<EasyTickets_WebAppContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new EasyTickets_WebAppContext(optionsBuilder.Options);
        }
    }
}
