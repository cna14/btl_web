using btl.Models;
using btl.Repository;
using Microsoft.AspNetCore.Mvc;
namespace btl.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp =  _loaiSp.GetAllLoaiSp().OrderBy(x=>x.MaLoai);
            return View(loaiSp);
        }
    }
}
