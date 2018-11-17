using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_Uklon_WebApplication.Interfaces;
using Test_Uklon_WebApplication.Models;
namespace Test_Uklon_WebApplication.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly UklonSiteContext _context;

        public OrderRepository(UklonSiteContext context)
        {
            _context = context;
        }

        public List<Order> Entities => _context.AllOrdersUklon.ToList();

        public Order Create(Order order)
        {
            var randomPrice = new Random();
            order.Price = randomPrice.Next(50, 100);

            //but better using Guid type data to do this
            order.Id = _context.AllOrdersUklon.Count() + 1;

            var createOrderentity = _context.AllOrdersUklon.Add(order).Entity;
            _context.SaveChanges();
            return createOrderentity;
        }

        public Order Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
            return _context.Entry(order).Entity;
        }

        public Order Edit(int id)
        {
            var order = _context.AllOrdersUklon.Find(id);
            return _context.Entry(order).Entity;
        }

        public Order GetEntity(int id)
        {
            return  _context.AllOrdersUklon.Find(id);
        }
    }
}
