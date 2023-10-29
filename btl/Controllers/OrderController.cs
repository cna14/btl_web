using Microsoft.AspNetCore.Mvc;

namespace btl.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
    }
}
