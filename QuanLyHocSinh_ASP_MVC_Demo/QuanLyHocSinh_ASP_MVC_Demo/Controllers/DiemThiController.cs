using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Controllers
{
    public class DiemThiController : Controller
    {
        public IActionResult Index()
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var listDiemThi = context.DiemThis.Include(h=>h.MaSvNavigation).Include(m=>m.MaMhNavigation).Include(p=>p.PhongHoc).ToList();
                return View(listDiemThi);
            }
            
        }
    }
}
