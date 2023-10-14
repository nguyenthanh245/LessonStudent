using Humanizer;
using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }

        public void ShowMessage(string message)
        {
            TempData["Message"] = message;
        }

        [HttpPost]
        public IActionResult LoginPage(HocSinh hocSinh)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
               
                var logHocSinh = context.HocSinhs.Where(x => x.Email.Equals(hocSinh.Email) && x.Passworld.Equals(hocSinh.Passworld)).FirstOrDefault();
                if (logHocSinh != null)
                {
                    if (logHocSinh.Spam == true)
                    {
                        ShowMessage(hocSinh.Email + " Login Ok !!!");
                        return RedirectToAction("Index", "HocSinh");
                    }
                    else if(logHocSinh.Spam == false)
                    {
                        ShowMessage(hocSinh.Email + " Account locked !!!");
                    }
                }
                else
                {
                    ShowMessage(hocSinh.Email + " Login fail!!!");
                }
                
                return View("LoginPage");


            }

        }
    }
}
