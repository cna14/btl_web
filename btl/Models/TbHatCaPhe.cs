using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class TbHatCaPhe
{
    public int Id { get; set; }

    public string? MaHat { get; set; }

    public string? TenHat { get; set; }

    public string? VungTrong { get; set; }

    public string? SoChe { get; set; }

    public string? DoCao { get; set; }

    public string? MucRang { get; set; }

    public string? HuongVi { get; set; }

    public DateTime? NgayRang { get; set; }

    public int? SoLuong { get; set; }
}
