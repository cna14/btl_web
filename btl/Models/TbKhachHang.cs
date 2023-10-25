using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class TbKhachHang
{
    public int Id { get; set; }

    public string? SoDienThoai { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }
}
