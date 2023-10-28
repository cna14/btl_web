using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class HoaDonBan
{
    public string MaHd { get; set; } = null!;

    public string? TenDangNhap { get; set; }

    public int? TongGia { get; set; }

    public string? MaGg { get; set; }

    public int? GiaBan { get; set; }

    public DateTime? NgayBan { get; set; }

    public string? GhiChu { get; set; }

    public virtual MaGiamGia? MaGgNavigation { get; set; }

    public virtual NguoiDung? TenDangNhapNavigation { get; set; }
}
