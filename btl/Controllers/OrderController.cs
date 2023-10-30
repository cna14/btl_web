using btl.Models;

using btl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace btl.Controllers
{
    public class OrderController : Controller
    {
        public Order? Order { get; set; }
        private readonly MoCoffeeAndBakeryContext _context;

        public OrderController(MoCoffeeAndBakeryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Order", HttpContext.Session.GetJson<Order>("order"));
        }

        public IActionResult AddToOrder(string maSp)
        {
            SanPham? sanPham = _context.SanPhams.FirstOrDefault(x=>x.MaSp == maSp);
            if (sanPham != null) 
            {
                Order = HttpContext.Session.GetJson<Order>("order") ?? new Order();
                Order.AddItem(sanPham, 1);
                HttpContext.Session.SetJson("order", Order);
            }
            return View("Order", Order);
        }
        public IActionResult RemoveFromOrder(string maSp)
        {
            SanPham? sanPham = _context.SanPhams.FirstOrDefault(x => x.MaSp == maSp);
            if (sanPham != null)
            {
                Order = HttpContext.Session.GetJson<Order>("order");
                Order.RemoveLine(sanPham);
                HttpContext.Session.SetJson("order", Order);
            }
            return View("Order", Order);
        }
        public IActionResult DecreaseOrder(string maSp)
        {
            SanPham? sanPham = _context.SanPhams.FirstOrDefault(x => x.MaSp == maSp);
            if (sanPham != null)
            {
                Order = HttpContext.Session.GetJson<Order>("order") ?? new Order();
                Order.AddItem(sanPham, -1);
                HttpContext.Session.SetJson("order", Order);
            }
            return View("Order", Order);
        }
    }
}
