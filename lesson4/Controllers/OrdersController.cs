using Microsoft.AspNetCore.Mvc;
using lesson4.Models;

namespace lesson4.Controllers
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, Title = "Order1", Description = "Description for Order 1", Price = 10.5m, Quantity = 2 },
            new Order { Id = 2, Title = "Order2", Description = "Description for Order 2", Price = 20.0m, Quantity = 1 },
            new Order { Id = 3, Title = "Order3", Description = "Description for Order 3", Price = 15.75m, Quantity = 3 }
        };

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View("Orders",orders);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return Content("Order not found");
            }

            return View("Details", order);
        }

        [HttpGet("search")]
        public IActionResult Search(string title)
        {
            var result = orders.Where(x => x.Title == title).ToList();

            return View("Search",result);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", order);
            }
            order.Id = orders.Count + 1;

            orders.Append(order);

            return View("Details",order);
        }

    }
}
