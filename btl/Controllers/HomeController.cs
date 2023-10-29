using System.Diagnostics;
using Azure;
using btl.Models;
using btl.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Web.Common;

namespace btl.Controllers
{
    public class HomeController : Controller
    {
        MoCoffeeAndBakeryContext a = new MoCoffeeAndBakeryContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = a.SanPhams.AsNoTracking().OrderBy(x => x.MaSp);
            PagedList<SanPham> list = new PagedList<SanPham>(listsanpham, pageNumber, pageSize);

            return View(list);
        }
        [Authentication]
        public IActionResult menu(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = a.SanPhams.AsNoTracking().OrderBy(x => x.MaSp);
            PagedList<SanPham> list = new PagedList<SanPham>(listsanpham, pageNumber, pageSize);

            return View(list);
        }
        [Authentication]
        public IActionResult SanPhamTheoLoai(string MaLoai, int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = a.SanPhams.AsNoTracking().Where
                (x=>x.MaLoai == MaLoai).OrderBy(x => x.MaSp);
            PagedList<SanPham> list = new PagedList<SanPham>(listsanpham, pageNumber, pageSize);
            ViewBag.MaLoai = MaLoai;
            return View(list);
        }
        [Authentication]
        public IActionResult Details(string MaSP)
        {
            var product = a.SanPhams.SingleOrDefault(x => x.MaSp == MaSP);
            return View(product);
        }
        [Authentication]
        public IActionResult DetailsClick(string MaSP)
        {
            var SanPham = a.SanPhams.SingleOrDefault(x=>x.MaSp == MaSP);
            var AnhSanPham = a.SanPhams.Where(x=>x.MaSp == MaSP).ToList();
            ViewBag.SanPham = SanPham;
            return View(SanPham);
        }
        [Authentication]
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