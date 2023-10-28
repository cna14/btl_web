using btl.Models;
namespace btl.Repository
{
    public interface ILoaiSpRepository
    {
        LoaiSp Add(LoaiSp LoaiSp);
        LoaiSp Update(LoaiSp LoaiSp);
        LoaiSp Delete(string MaLoai);
        LoaiSp GetLoaiSp(string MaLoai);
        IEnumerable<LoaiSp> GetAllLoaiSp();
    }
}
