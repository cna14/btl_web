using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class Qltin
{
    public int Id { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? Gmail { get; set; }

    public string? Tin { get; set; }

    public string? TenDangNhap { get; set; }

    public virtual NguoiDung? TenDangNhapNavigation { get; set; }
}
