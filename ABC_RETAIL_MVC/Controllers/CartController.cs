using ABC_RETAIL_MVC.Models;
using ABC_RETAIL_MVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using ABC_RETAIL_MVC.Data;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();
        return View(cart);
    }

    public IActionResult AddToCart(int id, string name, double price, string imageUrl)
    {
        var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();

        var item = cart.FirstOrDefault(p => p.ProductId == id);

        if (item != null)
        {
            item.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductId = id,
                ProductName = name,
                Price = price,
                ImageUrl = imageUrl,
                Quantity = 1
            });
        }

        HttpContext.Session.SetObject("cart", cart);
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();
        var item = cart.FirstOrDefault(p => p.ProductId == id);

        if (item != null)
            cart.Remove(item);

        HttpContext.Session.SetObject("cart", cart);

        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var cart = HttpContext.Session.GetObject<List<CartItem>>("cart") ?? new List<CartItem>();

        if (!cart.Any())
        {
            TempData["Error"] = "Your cart is empty.";
            return RedirectToAction("Index");
        }

        // TEMP: use a fixed customerId (replace with real login later)
        int customerId = 1;

        foreach (var item in cart)
        {
            var order = new Order
            {
                CustomerId = customerId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                OrderDate = DateTime.Now
            };

            _context.Orders.Add(order);
        }

        _context.SaveChanges();

        // Clear cart after saving order
        HttpContext.Session.SetObject("cart", new List<CartItem>());

        return RedirectToAction("OrderPlaced");
    }

    public IActionResult OrderPlaced()
    {
        return View();
    }
}
