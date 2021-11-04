using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NKSLK.Models.DTO
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CongNhan> CongNhans { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<DanhMucCongNhan> DanhMucCongNhans { get; set; }
        public virtual DbSet<DanhMucCongViec> DanhMucCongViecs { get; set; }
        public virtual DbSet<NhatKySLK> NhatKySLKs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ToNhanCong> ToNhanCongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongNhan>()
                .Property(e => e.LuongHD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CongNhan>()
                .Property(e => e.LuongBaoHiem)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CongNhan>()
                .HasMany(e => e.DanhMucCongNhans)
                .WithRequired(e => e.CongNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.DinhMucKhoan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.DinhMucLD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CongViec>()
                .HasMany(e => e.DanhMucCongViecs)
                .WithRequired(e => e.CongViec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan1)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<ToNhanCong>()
                .HasMany(e => e.DanhMucCongNhans)
                .WithRequired(e => e.ToNhanCong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ToNhanCong>()
                .HasMany(e => e.DanhMucCongViecs)
                .WithRequired(e => e.ToNhanCong)
                .WillCascadeOnDelete(false);
        }
    }
}
