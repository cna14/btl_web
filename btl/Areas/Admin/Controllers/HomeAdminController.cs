using btl.Models;
using btl.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace btl.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    //[Route("admin/homeadmin")]

    public class HomeAdminController : Controller
    {
        MoCoffeeAndBakeryContext a = new MoCoffeeAndBakeryContext();
        [Route("")]
        [Route("index")]
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }

        //Quản lý sản phẩm
        [Route("danhmucsanpham")]
        [Authentication]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = a.SanPhams.AsNoTracking().OrderBy(x => x.MaSp);
            PagedList<SanPham> list = new PagedList<SanPham>(listsanpham, pageNumber, pageSize);

            return View(list);
        }

        //Them
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        [Authentication]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaLoai = new SelectList(a.LoaiSps.ToList(), "MaLoai", "TenLoai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                a.SanPhams.Add(sanPham);
                a.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }

        //Sửa
        [Route("SuaSanPham")]
        [HttpGet]
        [Authentication]
        public IActionResult SuaSanPham(string maSp)
        {
            ViewBag.MaLoai = new SelectList(a.LoaiSps.ToList(), "MaLoai", "TenLoai");
            var sanPham = a.SanPhams.Find(maSp);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                a.Entry(sanPham).State = EntityState.Modified;
                a.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        //Xóa
        [Route("XoaSanPham")]
        [HttpGet]
        [Authentication]
        public IActionResult XoaSanPham(string maSp)
        {
            TempData["Message"] = "";
            var cthdban = a.ChiTietHdbs.Where(x=>x.MaSp==maSp);
            if (cthdban.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DanhMucSanPham");
            }
            a.Remove(a.SanPhams.Find(maSp));
            a.SaveChanges();
            TempData["Message"] = "Đã xóa sản phẩm có mã: " + maSp;
            return RedirectToAction("DanhMucSanPham");
        }



        //Quản lý loại sản phẩm
        [Route("QLLoaiSP")]
        [Authentication]
        public IActionResult QLLoaiSP(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listloai = a.LoaiSps.AsNoTracking().OrderBy(x => x.MaLoai);
            PagedList<LoaiSp> list = new PagedList<LoaiSp>(listloai, pageNumber, pageSize);

            return View(list);
        }



        //Quản lý mã giảm giá
        [Route("QLMaGiamGia")]
        [Authentication]
        public IActionResult QLMaGiamGia(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listmagg = a.MaGiamGia.AsNoTracking().OrderBy(x => x.MaGg);
            PagedList<MaGiamGia> list = new PagedList<MaGiamGia>(listmagg, pageNumber, pageSize);

            return View(list);
        }



        //Quản lý hóa đơn
        [Route("QLHDB")]
        [Authentication]
        public IActionResult QLHDB(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listhd = a.HoaDonBans.AsNoTracking().OrderBy(x => x.MaHd);
            PagedList<HoaDonBan> list = new PagedList<HoaDonBan>(listhd, pageNumber, pageSize);

            return View(list);
        }



        //Quản lý tài khoản
        [Route("QLNguoiDung")]
        [Authentication]
        public IActionResult QLNguoiDung(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listnguoidung = a.NguoiDungs.AsNoTracking().OrderBy(x => x.TenDangNhap);
            PagedList<NguoiDung> list = new PagedList<NguoiDung>(listnguoidung, pageNumber, pageSize);

            return View(list);
        }

        //Them
        [Route("ThemNguoiDung")]
        [HttpGet]
        [Authentication]
        public IActionResult ThemNguoiDung()
        {
            return View();
        }
        [Route("ThemNguoiDung")]
        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNguoiDung(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                a.NguoiDungs.Add(nguoiDung);
                a.SaveChanges();
                return RedirectToAction("ThemNguoiDung");
            }
            return View(nguoiDung);
        }

        //Sửa
        [Route("SuaNguoiDung")]
        [HttpGet]
        [Authentication]
        public IActionResult SuaNguoiDung(string tenDangNhap)
        {
            var nguoiDung = a.NguoiDungs.Find(tenDangNhap);
            return View(nguoiDung);
        }
        [Route("SuaNguoiDung")]
        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNguoiDung(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                a.Entry(nguoiDung).State = EntityState.Modified;
                a.SaveChanges();
                return RedirectToAction("QLNguoiDung", "HomeAdmin");
            }
            return View(nguoiDung);
        }
    }
}
