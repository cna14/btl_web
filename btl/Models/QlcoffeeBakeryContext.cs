using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace btl.Models;

public partial class QlcoffeeBakeryContext : DbContext
{
    public QlcoffeeBakeryContext()
    {
    }

    public QlcoffeeBakeryContext(DbContextOptions<QlcoffeeBakeryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbChiTietBanh> TbChiTietBanhs { get; set; }

    public virtual DbSet<TbChiTietCaPhe> TbChiTietCaPhes { get; set; }

    public virtual DbSet<TbChiTietHoaDon> TbChiTietHoaDons { get; set; }

    public virtual DbSet<TbHatCaPhe> TbHatCaPhes { get; set; }

    public virtual DbSet<TbHoaDonBan> TbHoaDonBans { get; set; }

    public virtual DbSet<TbKhachHang> TbKhachHangs { get; set; }

    public virtual DbSet<TbSanPham> TbSanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CNA;Initial Catalog=QLcoffee_bakery;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbChiTietBanh>(entity =>
        {
            entity.ToTable("tb_ChiTietBanh");

            entity.Property(e => e.CotBanh).HasMaxLength(50);
            entity.Property(e => e.HinhDang).HasMaxLength(50);
            entity.Property(e => e.HuongVi).HasMaxLength(50);
            entity.Property(e => e.KichThuoc).HasMaxLength(50);
            entity.Property(e => e.MaBanh).HasMaxLength(10);
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.NguyenLieu).HasMaxLength(50);
        });

        modelBuilder.Entity<TbChiTietCaPhe>(entity =>
        {
            entity.ToTable("tb_ChiTietCaPhe");

            entity.Property(e => e.MaHat).HasMaxLength(10);
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.ThanhPhan).HasMaxLength(50);
        });

        modelBuilder.Entity<TbChiTietHoaDon>(entity =>
        {
            entity.ToTable("tb_ChiTietHoaDon");

            entity.Property(e => e.GiamGia).HasColumnType("money");
            entity.Property(e => e.MaHoaDon).HasMaxLength(10);
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
        });

        modelBuilder.Entity<TbHatCaPhe>(entity =>
        {
            entity.ToTable("tb_HatCaPhe");

            entity.Property(e => e.DoCao).HasMaxLength(50);
            entity.Property(e => e.HuongVi).HasMaxLength(50);
            entity.Property(e => e.MaHat).HasMaxLength(10);
            entity.Property(e => e.MucRang).HasMaxLength(50);
            entity.Property(e => e.NgayRang).HasColumnType("date");
            entity.Property(e => e.SoChe).HasMaxLength(50);
            entity.Property(e => e.TenHat).HasMaxLength(50);
            entity.Property(e => e.VungTrong).HasMaxLength(50);
        });

        modelBuilder.Entity<TbHoaDonBan>(entity =>
        {
            entity.ToTable("tb_HoaDonBan");

            entity.Property(e => e.MaHoaDon).HasMaxLength(10);
            entity.Property(e => e.NgayXuatHd)
                .HasColumnType("date")
                .HasColumnName("NgayXuatHD");
            entity.Property(e => e.SoDienThoai).HasMaxLength(12);
            entity.Property(e => e.TongGiaTien).HasColumnType("money");
        });

        modelBuilder.Entity<TbKhachHang>(entity =>
        {
            entity.ToTable("tb_KhachHang");

            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(12);
        });

        modelBuilder.Entity<TbSanPham>(entity =>
        {
            entity.ToTable("tb_SanPham");

            entity.Property(e => e.GiaTien).HasColumnType("money");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
