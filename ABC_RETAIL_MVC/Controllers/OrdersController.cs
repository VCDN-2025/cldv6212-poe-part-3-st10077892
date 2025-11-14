using System.Linq;
using ABC_RETAIL_MVC.Data;
using ABC_RETAIL_MVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace ABC_RETAIL_MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public IActionResult Index()
        {
            // Include Customer and Product info for display
            var orders = _context.Orders
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    Customer = o.Customer,
                    ProductId = o.ProductId,
                    Product = o.Product,
                    Quantity = o.Quantity,
                    OrderDate = o.OrderDate
                }).ToList();

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now; // Set current date
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }
    }
}
