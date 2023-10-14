using System;
using System.Collections.Generic;

namespace QuanLyHocSinh_ASP_MVC_Demo.Models
{
    public partial class ChuyenKhoa
    {
        public ChuyenKhoa()
        {
            HocSinhs = new HashSet<HocSinh>();
        }

        public string MaKhoa { get; set; } = null!;
        public string TenKhoa { get; set; } = null!;
        public string? SoDienThoai { get; set; }
        public bool? Spam { get; set; }

        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}
