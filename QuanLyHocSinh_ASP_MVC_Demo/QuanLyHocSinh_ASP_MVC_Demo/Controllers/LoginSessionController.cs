using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Controllers
{
    public class LoginSessionController : Controller
    {
        QuanLyHocSinhContext context = new QuanLyHocSinhContext();

        [HttpGet]
        public IActionResult LoginSession()
        {
            if(HttpContext.Session.GetString("HoTen") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HocSinh");
            }
            ;
        }

       

       
    }
}
