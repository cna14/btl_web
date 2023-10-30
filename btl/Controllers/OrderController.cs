using btl.Models;
using btl.Models.ViewModels;
using btl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace btl.Controllers
{
    public class OrderController : Controller
    {
        private readonly MoCoffeeAndBakeryContext dataContext;

        public OrderController(MoCoffeeAndBakeryContext context)
        {
            dataContext = context;
        }

        public IActionResult Order()
        {
            List<OrderItemModel> orderItems = HttpContext.Session.GetJson<List<OrderItemModel>>("Order") ?? new List<OrderItemModel>();
            OrderItiemViewModel cartVM = new()
            {
                OrderItems = orderItems,
                TongTien = orderItems.Sum(x => x.SoLuongb * x.GiaBan)

            };
            return View(cartVM);
        }

        public async Task<IActionResult> Add(string maSp)
        {
            SanPham sanPham = await dataContext.SanPhams.FindAsync(maSp);
            List<OrderItemModel> order = HttpContext.Session.GetJson<List<OrderItemModel>>("Order") ?? new List<OrderItemModel>();
            OrderItemModel orderItems = order.Where(x=>x.MaSp == maSp).FirstOrDefault();

            if (orderItems == null)
            {
                order.Add(new OrderItemModel(sanPham));
            }
            else
            {
                orderItems.SoLuongb += 1;
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
