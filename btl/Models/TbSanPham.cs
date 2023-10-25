using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class TbSanPham
{
    public int Id { get; set; }

    public string? MaSp { get; set; }

    public string? TenSp { get; set; }

    public decimal? GiaTien { get; set; }
}
