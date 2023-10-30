namespace btl.Models
{
    public class Order
    {
        public List<OrderLine> Lines { get; set; } = new List<OrderLine>();

        public void AddItem(SanPham sanPham, int soLuong)
        {
            OrderLine? line = Lines.Where(x=>x.SanPham.MaSp == sanPham.MaSp).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new OrderLine()
                {
                    SanPham = sanPham,
                    SoLuongb = soLuong
                });
            } else
            {
                line.SoLuongb += soLuong;
            }
        }

        public void RemoveLine(SanPham sanPham) => Lines.RemoveAll(x=>x.SanPham.MaSp == sanPham.MaSp);

        public int TotalValue() => (int)Lines.Sum(x => x.SanPham.GiaBan * x.SoLuongb);

        public void Clear() => Lines.Clear();
    }

    public class OrderLine
    {
        public string MaSp { get; set; }

        public SanPham SanPham { get; set; }

        public int SoLuongb { get; set; }
    }
}
