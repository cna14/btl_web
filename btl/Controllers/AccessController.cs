using Microsoft.AspNetCore.Mvc;
using btl.Models;

namespace btl.Controllers
{
    public class AccessController : Controller
    {
        MoCoffeeAndBakeryContext a = new MoCoffeeAndBakeryContext();

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("TenDangNhap")==null)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(NguoiDung nguoiDung)
        {
            if (HttpContext.Session.GetString("TenDangNhap")== null)
            {
                var tdn = a.NguoiDungs.Where(x=>x.TenDangNhap.Equals(nguoiDung.TenDangNhap) && x.MatKhau.Equals(nguoiDung.MatKhau)).FirstOrDefault();
                if (tdn!=null)
                {
                    HttpContext.Session.SetString("TenDangNhap", tdn.TenDangNhap.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TenDangNhap");
            return RedirectToAction("Login", "Access");
        }
    }
}
