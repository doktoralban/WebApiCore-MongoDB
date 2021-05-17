using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore_MongoDB.Models;
using WebApiCore_MongoDB.Services;

namespace WebApiCore_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("GetOrderAndDetails")]
        public ActionResult<List<vOrdersAndDetails>> GetOrderAndDetails() =>
          _orderService.GetOrderAndDetails();



    }
}
