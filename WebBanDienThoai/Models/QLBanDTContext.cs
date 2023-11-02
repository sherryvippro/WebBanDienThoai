using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBanDienThoai.Models
{
    public partial class QLBanDTContext : DbContext
    {
        public QLBanDTContext()
        {
        }

        public QLBanDTContext(DbContextOptions<QLBanDTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; } = null!;
        public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; } = null!;
        public virtual DbSet<TChiTietHdn> TChiTietHdns { get; set; } = null!;
        public virtual DbSet<THang> THangs { get; set; } = null!;
        public virtual DbSet<THoaDonBan> THoaDonBans { get; set; } = null!;
        public virtual DbSet<THoaDonNhap> THoaDonNhaps { get; set; } = null!;
        public virtual DbSet<TNhaCungCap> TNhaCungCaps { get; set; } = null!;
        public virtual DbSet<TSp> TSp { get; set; } = null!;
        public virtual DbSet<TTheLoai> TTheLoais { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HP034J7\\SQLEXPRESS;Initial Catalog=QLBanDT;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung)
                    .HasName("PK_Khachhang");

                entity.ToTable("Nguoidung");

                entity.Property(e => e.Anhdaidien)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Diachi).HasMaxLength(100);

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Hoten).HasMaxLength(50);

                entity.Property(e => e.Idquyen).HasColumnName("IDQuyen");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhanQuyen>(entity =>
            {
                entity.HasKey(e => e.Idquyen);

                entity.ToTable("PhanQuyen");

                entity.Property(e => e.Idquyen).HasColumnName("IDQuyen");

                entity.Property(e => e.TenQuyen).HasMaxLength(20);
            });

            modelBuilder.Entity<TChiTietHdb>(entity =>
            {
                entity.HasKey(e => new { e.SoHdb, e.MaSp });

                entity.ToTable("tChiTietHDB");

                entity.Property(e => e.SoHdb)
                    .HasMaxLength(10)
                    .HasColumnName("SoHDB");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP");

                entity.Property(e => e.KhuyenMai).HasMaxLength(100);

                entity.Property(e => e.Slban).HasColumnName("SLBan");
            });

            modelBuilder.Entity<TChiTietHdn>(entity =>
            {
                entity.HasKey(e => new { e.SoHdn, e.MaSp });

                entity.ToTable("tChiTietHDN");

                entity.Property(e => e.SoHdn)
                    .HasMaxLength(10)
                    .HasColumnName("SoHDN");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP");

                entity.Property(e => e.KhuyenMai).HasMaxLength(100);

                entity.Property(e => e.Slnhap).HasColumnName("SLNhap");
            });

            modelBuilder.Entity<THang>(entity =>
            {
                entity.HasKey(e => e.MaHang)
                    .HasName("PK_tTheLoai");

                entity.ToTable("tHang");

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.TenHang).HasMaxLength(100);
            });

            modelBuilder.Entity<THoaDonBan>(entity =>
            {
                entity.HasKey(e => e.SoHdb);

                entity.ToTable("tHoaDonBan");

                entity.Property(e => e.SoHdb)
                    .HasMaxLength(10)
                    .HasColumnName("SoHDB");

                entity.Property(e => e.MaNguoiDung).HasMaxLength(10);

                entity.Property(e => e.NgayBan).HasColumnType("datetime");

                entity.Property(e => e.TongHdb)
                    .HasColumnType("money")
                    .HasColumnName("TongHDB");
            });

            modelBuilder.Entity<THoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.SoHdn);

                entity.ToTable("tHoaDonNhap");

                entity.Property(e => e.SoHdn)
                    .HasMaxLength(10)
                    .HasColumnName("SoHDN");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(10)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.TongHdn)
                    .HasColumnType("money")
                    .HasColumnName("TongHDN");
            });

            modelBuilder.Entity<TNhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc);

                entity.ToTable("tNhaCungCap");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(10)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(200)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<TSp>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK_tSach");

                entity.ToTable("tSP");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP");

                entity.Property(e => e.Anh).HasColumnType("image");

                entity.Property(e => e.DonGiaBan).HasColumnType("money");

                entity.Property(e => e.DonGiaNhap).HasColumnType("money");

                entity.Property(e => e.MaHang).HasMaxLength(10);

                entity.Property(e => e.MaTl)
                    .HasMaxLength(10)
                    .HasColumnName("MaTL");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(200)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<TTheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTl)
                    .HasName("PK_tNhaXuatBan");

                entity.ToTable("tTheLoai");

                entity.Property(e => e.MaTl)
                    .HasMaxLength(10)
                    .HasColumnName("MaTL");

                entity.Property(e => e.TenTl)
                    .HasMaxLength(100)
                    .HasColumnName("TenTL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
