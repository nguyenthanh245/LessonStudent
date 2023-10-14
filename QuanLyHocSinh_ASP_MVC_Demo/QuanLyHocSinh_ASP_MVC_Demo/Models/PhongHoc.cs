using System;
using System.Collections.Generic;

namespace QuanLyHocSinh_ASP_MVC_Demo.Models
{
    public partial class PhongHoc
    {
        public PhongHoc()
        {
            DiemThis = new HashSet<DiemThi>();
        }

        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = null!;

        public virtual ICollection<DiemThi> DiemThis { get; set; }
    }
}
