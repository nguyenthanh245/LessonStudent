using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Pages.DiemThis
{
    public class IndexModel : PageModel
    {
        public List<DiemThi> listDiemThi { get; set; }
        public void OnGet()
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                listDiemThi = context.DiemThis.ToList();
            }
        }
    }
}
