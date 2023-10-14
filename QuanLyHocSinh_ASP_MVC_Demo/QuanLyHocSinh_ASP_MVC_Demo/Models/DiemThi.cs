using System;
using System.Collections.Generic;

namespace QuanLyHocSinh_ASP_MVC_Demo.Models
{
    public partial class DiemThi
    {
        public string MaSv { get; set; } = null!;
        public int MaMh { get; set; }
        public double? Diem { get; set; }
        public DateTime? NgayThi { get; set; }
        public int? PhongHocId { get; set; }

        public virtual MonHoc MaMhNavigation { get; set; } = null!;
        public virtual HocSinh MaSvNavigation { get; set; } = null!;
        public virtual PhongHoc? PhongHoc { get; set; }
    }
}
