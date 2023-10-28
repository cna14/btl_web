using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public int? GiaBan { get; set; }

    public string? MoTa { get; set; }

    public string? DuongDanAnh { get; set; }

    public string? MoTaChiTiet { get; set; }

    public int? SoLuong { get; set; }

    public string? MaLoai { get; set; }

    public virtual LoaiSp? MaLoaiNavigation { get; set; }
}
