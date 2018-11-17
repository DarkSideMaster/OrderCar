using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Test_Uklon_WebApplication.Models;
using Test_Uklon_WebApplication.Repositories;

namespace Test_Uklon_WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public OrdersController(UklonSiteContext context)
        {
            _orderRepository = new OrderRepository(context);
        }

        public IActionResult AllOrdersView()
        {
            return View(_orderRepository.Entities);
        }

        [HttpGet]
        public IActionResult CreateOrdersView()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
                return NotFound();
            }
            try
            {
                _orderRepository.Create(order);
                return RedirectToAction("AllOrdersView");
            }
            catch
            {
                BadRequest(ModelState); 
                return NotFound();
            }
        }


        [HttpGet]
        public IActionResult EditOrdersView(int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
                return NotFound();
            }
            return View(_orderRepository.Edit(id));
        }


        [HttpPost]
        public IActionResult EditOrdersView(Order order)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
                return NotFound(); 
            }

            try
            {
                _orderRepository.Update(order);
                return RedirectToAction("AllOrdersView");
            }
            catch
            {
                return NotFound(); 
            }
        }

        [HttpPost]
        public IActionResult Cancel(int id)
        {       
            var order = _orderRepository.GetEntity(id);

            if (order == null || order.Canceled)
            {
                return BadRequest();
            }

            order.Canceled = true;
            _orderRepository.Update(order);

            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 
