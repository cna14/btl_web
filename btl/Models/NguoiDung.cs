using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class NguoiDung
{
    public string TenDangNhap { get; set; } = null!;

    public string? MatKhau { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Gmail { get; set; }

    public bool? LoaiDangNhap { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual ICollection<Qltin> Qltins { get; set; } = new List<Qltin>();
}
