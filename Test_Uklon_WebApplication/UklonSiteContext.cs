using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_Uklon_WebApplication.Models;

namespace Test_Uklon_WebApplication
{
    public class UklonSiteContext :DbContext
    {
        public DbSet<Order> AllOrdersUklon { get; set; }

        public UklonSiteContext(DbContextOptions<UklonSiteContext> options)
            : base(options)
        {
            
        }

    }
}
 
