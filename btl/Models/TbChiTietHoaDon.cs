using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class TbChiTietHoaDon
{
    public int Id { get; set; }

    public string? MaHoaDon { get; set; }

    public int? SoLuongMua { get; set; }

    public decimal? GiamGia { get; set; }

    public string? MaSp { get; set; }
}
