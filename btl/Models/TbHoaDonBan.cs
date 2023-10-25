using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class TbHoaDonBan
{
    public int Id { get; set; }

    public DateTime? NgayXuatHd { get; set; }

    public decimal? TongGiaTien { get; set; }

    public bool? HinhThuc { get; set; }

    public string? SoDienThoai { get; set; }

    public string? MaHoaDon { get; set; }
}
