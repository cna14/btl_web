namespace btl.Models
{
    public class OrderItemModel
    {
        public string MaSp { get; set; }

        public string? DuongDanAnh { get; set; }

        public string? TenSp { get; set; }

        public int GiaBan { get; set; }

        public int SoLuongb { get; set; }

        public int? TongGia 
        {
            get {  return GiaBan*SoLuongb; }
        }

        public OrderItemModel()
        {

        }

        public OrderItemModel(SanPham sanPham)
        {
            MaSp = sanPham.MaSp;
            DuongDanAnh = sanPham.DuongDanAnh;
            TenSp = sanPham.TenSp;
            GiaBan = (int)sanPham.GiaBan;
            SoLuongb = 1;
        }
    }
}
