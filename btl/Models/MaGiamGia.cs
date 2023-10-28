using System;
using System.Collections.Generic;

namespace btl.Models;

public partial class MaGiamGia 
{
    public string MaGg { get; set; } = null!;

    public int? SoTienGiam { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();
}
