using System.Diagnostics;
using Azure;
using btl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Web.Common;

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
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = a.TbSanPhams.AsNoTracking().OrderBy(x => x.Id);
            PagedList<TbSanPham> list = new PagedList<TbSanPham>(listsanpham, pageNumber, pageSize);

            return View(list);
        }
        public IActionResult menu(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = a.TbSanPhams.AsNoTracking().OrderBy(x => x.Id);
            PagedList<TbSanPham> list = new PagedList<TbSanPham>(listsanpham, pageNumber, pageSize);

            return View(list);
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