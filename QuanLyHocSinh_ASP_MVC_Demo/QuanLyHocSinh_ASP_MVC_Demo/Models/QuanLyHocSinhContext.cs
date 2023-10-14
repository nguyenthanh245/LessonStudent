using Microsoft.EntityFrameworkCore;

namespace QuanLyHocSinh_ASP_MVC_Demo.Models
{
    public partial class QuanLyHocSinhContext : DbContext
    {
        public QuanLyHocSinhContext()
        {
        }

        public QuanLyHocSinhContext(DbContextOptions<QuanLyHocSinhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuyenKhoa> ChuyenKhoas { get; set; } = null!;
        public virtual DbSet<DiemThi> DiemThis { get; set; } = null!;
        public virtual DbSet<HocSinh> HocSinhs { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<PhongHoc> PhongHocs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.; database =QuanLyHocSinh;uid=sa;pwd=123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenKhoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa);

                entity.ToTable("ChuyenKhoa");

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TenKhoa).HasMaxLength(100);
            });

            modelBuilder.Entity<DiemThi>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.MaMh });

                entity.ToTable("DiemThi");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.MaMh).HasColumnName("MaMH");

                entity.Property(e => e.NgayThi).HasColumnType("date");

                entity.Property(e => e.PhongHocId).HasColumnName("PhongHocID");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.DiemThis)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiemThi_MonHoc");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.DiemThis)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiemThi_HocSinh");

                entity.HasOne(d => d.PhongHoc)
                    .WithMany(p => p.DiemThis)
                    .HasForeignKey(d => d.PhongHocId)
                    .HasConstraintName("FK_DiemThi_PhongHoc");
            });

            modelBuilder.Entity<HocSinh>(entity =>
            {
                entity.HasKey(e => e.MaSv);

                entity.ToTable("HocSinh");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Passworld)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK_HocSinh_ChuyenKhoa");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh);

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMh).HasColumnName("MaMH");

                entity.Property(e => e.Status).HasMaxLength(500);

                entity.Property(e => e.TenMonHoc).HasMaxLength(100);
            });

            modelBuilder.Entity<PhongHoc>(entity =>
            {
                entity.HasKey(e => e.MaPhong);

                entity.ToTable("PhongHoc");

                entity.Property(e => e.TenPhong).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
