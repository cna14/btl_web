using System.Diagnostics;
using btl.Models;
using Microsoft.AspNetCore.Mvc;

namespace btl.Controllers
{
    public class HomeController : Controller
    {
        QlcoffeeBakeryContext a = new QlcoffeeBakeryContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listsanpham = a.TbSanPhams.ToList();
            return View(listsanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}