using System;
using System.Collections.Generic;

namespace QuanLyHocSinh_ASP_MVC_Demo.Models
{
    public partial class HocSinh
    {
        public HocSinh()
        {
            DiemThis = new HashSet<DiemThi>();
        }

        public string MaSv { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public bool? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? MaKhoa { get; set; }
        public string? Passworld { get; set; }
        public bool? Spam { get; set; }

        public virtual ChuyenKhoa? MaKhoaNavigation { get; set; }
        public virtual ICollection<DiemThi> DiemThis { get; set; }
    }
}
