using ABC_RETAIL_MVC.Models;
using ABC_RETAIL_MVC.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
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
}
