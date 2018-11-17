using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Uklon_WebApplication.Models;

namespace Test_Uklon_WebApplication.Database
{
    public class DatabaseExtensions
    {
        public static void Initialize(UklonSiteContext context)
        {
            if (!context.AllOrdersUklon.Any())
            {
                context.AllOrdersUklon.AddRange(
                    new Order()
                    {
                        Id = 1,
                        AddressFrom = "м. Хрещатик",
                        AddressTo = "м.Почайна",
                        Phone = "380501234567",
                        Price = 75,
                        Canceled = false,
                    },
                    new Order()
                    {
                        Id = 2,
                        AddressFrom = "м. Академгородок",
                        AddressTo = "м.Почайна",
                        Phone = "380504567123",
                        Price = 50,
                        Canceled = false,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
