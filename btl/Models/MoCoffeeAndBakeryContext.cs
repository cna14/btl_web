using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace btl.Models;

public partial class MoCoffeeAndBakeryContext : DbContext
{
    public MoCoffeeAndBakeryContext()
    {
    }

    public MoCoffeeAndBakeryContext(DbContextOptions<MoCoffeeAndBakeryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<MaGiamGia> MaGiamGia { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<Qltin> Qltins { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01;Initial Catalog=MoCoffeeAndBakery;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChiTietHDB");

            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");

            entity.HasOne(d => d.MaHdNavigation).WithMany()
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("fk_ChiTietHDB_MaHD");

            entity.HasOne(d => d.MaSpNavigation).WithMany()
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("fk_ChiTietHDB_MaSP");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("pk_HoaDonBan_MaHD");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .HasColumnName("MaHD");
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.MaGg)
                .HasMaxLength(10)
                .HasColumnName("MaGG");
            entity.Property(e => e.NgayBan).HasColumnType("date");
            entity.Property(e => e.TenDangNhap).HasMaxLength(20);

            entity.HasOne(d => d.MaGgNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaGg)
                .HasConstraintName("fk_HoaDonBan_MaGG");

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("fk_HoaDonBan_TenDangNhap");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("pk_LoaiSP_MaLoai");

            entity.ToTable("LoaiSP");

            entity.Property(e => e.MaLoai).HasMaxLength(10);
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<MaGiamGia>(entity =>
        {
            entity.HasKey(e => e.MaGg).HasName("pk_MaGiamGia_MaGG");

            entity.Property(e => e.MaGg)
                .HasMaxLength(10)
                .HasColumnName("MaGG");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("pk_NguoiDung_TenDangNhap");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.TenDangNhap).HasMaxLength(20);
            entity.Property(e => e.DiaChi).HasMaxLength(1000);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.Gmail).HasMaxLength(100);
            entity.Property(e => e.Ho).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(20);
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<Qltin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_QLTin_Id");

            entity.ToTable("QLTin");

            entity.Property(e => e.Gmail).HasMaxLength(100);
            entity.Property(e => e.Ho).HasMaxLength(100);
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenDangNhap).HasMaxLength(20);
            entity.Property(e => e.Tin).HasMaxLength(2000);

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.Qltins)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("fk_QLTin_TenDangNhap");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("pk_SanPham_MaSP");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.DuongDanAnh).HasMaxLength(1000);
            entity.Property(e => e.MaLoai).HasMaxLength(10);
            entity.Property(e => e.MoTa).HasMaxLength(100);
            entity.Property(e => e.MoTaChiTiet).HasMaxLength(1000);
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("fk_SanPham_MaLoai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
