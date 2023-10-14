using System;
using System.Collections.Generic;

namespace QuanLyHocSinh_ASP_MVC_Demo.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            DiemThis = new HashSet<DiemThi>();
        }

        public int MaMh { get; set; }
        public string TenMonHoc { get; set; } = null!;
        public double? SoTinChi { get; set; }
        public string? Status { get; set; }
        public bool? Spam { get; set; }

        public virtual ICollection<DiemThi> DiemThis { get; set; }
    }
}
