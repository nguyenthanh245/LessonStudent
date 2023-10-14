using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuanLyHocSinh_ASP_MVC_Demo.Pages.HocSinhs
{
    public class IndexModel : PageModel
    {
        public string Thanh { get; set; }

        public void OnGet()
        {
            Thanh = "10 diem";
        }
    }
}
