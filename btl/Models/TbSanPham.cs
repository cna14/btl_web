using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class TbSanPham
{
    public int Id { get; set; }

    public string? MaSp { get; set; }

    public string? TenSp { get; set; }

    public Decimal? GiaTien { get; set; }

    public Boolean? IsBanh { get; set; }

    public string? MoTa { get; set; }

    public int? SoLuong { get; set; }

    public string? DuongDanAnh { get; set; }
}
