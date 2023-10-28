using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class ChiTietHdb
{
    public string? MaSp { get; set; }

    public string? MaHd { get; set; }

    public int? SoLuong { get; set; }

    public virtual HoaDonBan? MaHdNavigation { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
