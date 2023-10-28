using btl.Models;
namespace btl.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly MoCoffeeAndBakeryContext _context;
        public LoaiSpRepository(MoCoffeeAndBakeryContext context)
        {
            _context = context;
        }
        public LoaiSp Add(LoaiSp LoaiSp)
        {
            _context.LoaiSps.Add(LoaiSp);
            _context.SaveChanges();
            return LoaiSp;
        }

        public LoaiSp Delete(string MaLoai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSp> GetAllLoaiSp()
        {
            return _context.LoaiSps;
        }

        public LoaiSp GetLoaiSp(string MaLoai)
        {
            return _context.LoaiSps.Find(MaLoai);
        }

        public LoaiSp Update(LoaiSp LoaiSp)
        {
            _context.Update(LoaiSp);
            _context.SaveChanges();
            return LoaiSp;
        }
    }
}
