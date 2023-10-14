using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Controllers
{
    public class ChuyenKhoaController : Controller
    {
        public IActionResult Index(int message = 2)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var lstChuyenKhoa = context.ChuyenKhoas.ToList();
                ViewBag.message = message;

                return View("Index",lstChuyenKhoa);
            }

        }
        public IActionResult AddChuyenKhoa(int message = 4)
        {
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public IActionResult AddChuyenKhoa(ChuyenKhoa chuyenKhoa)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                context.ChuyenKhoas.Add(chuyenKhoa);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index",new { message = 3});
                }
                else
                {
                    return RedirectToAction("AddChuyenKhoa",new { message = 0});
                }
            }
        }

        public IActionResult DetailChuyenKhoa(string maChuyenKhoa)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var chuyenKhoa = context.ChuyenKhoas.FirstOrDefault(x => x.MaKhoa.Equals(maChuyenKhoa));
                    return View(chuyenKhoa);
            }

        }
        public IActionResult UpdateChuyenKhoa(string maChuyenKhoa)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var chuyenKhoa = context.ChuyenKhoas.FirstOrDefault(x => x.MaKhoa.Equals(maChuyenKhoa));
                return View(chuyenKhoa);
            }

        }

        [HttpPost]
        public IActionResult UpdateChuyenKhoa(ChuyenKhoa chuyenKhoa)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                context.ChuyenKhoas.Update(chuyenKhoa);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("UpdateChuyenKhoa");
                }

            }
        }

        public IActionResult DeleteChuyenKhoa(string maChuyenKhoa)
        {
            using(QuanLyHocSinhContext context =new QuanLyHocSinhContext())
            {
                var chuyenKhoa = context.ChuyenKhoas.Include(h => h.HocSinhs).FirstOrDefault(c => c.MaKhoa.Equals(maChuyenKhoa));
                
                try
                {
                    if(chuyenKhoa != null)
                    {
                        if(chuyenKhoa.HocSinhs.Count() > 0)
                        {
                            foreach (HocSinh item in chuyenKhoa.HocSinhs)
                            {
                                List<DiemThi> listDiemThi = 
                                    context.DiemThis
                                    .Where(x => x.MaSv.Equals(item.MaSv)).ToList();
                                if(listDiemThi.Count() > 0)
                                {
                                    context.DiemThis.RemoveRange(listDiemThi);
                                    context.SaveChanges();
                                }
                            }
                            context.HocSinhs.RemoveRange(chuyenKhoa.HocSinhs);
                            context.SaveChanges();  
                        }
                        context.ChuyenKhoas.Remove(chuyenKhoa);
                        context.SaveChanges();
                        return RedirectToAction("Index", new {message = 1});
                    }
                }catch(Exception ex)
                {
                    
                }
                return RedirectToAction("Index", new { message = 0 });
            }
        }

        public IActionResult SpamChuyenKhoa(string maChuyenKhoa)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var chuyenKhoa = context.ChuyenKhoas.FirstOrDefault(x => x.MaKhoa.Equals(maChuyenKhoa));
                if(chuyenKhoa != null)
                {
                    chuyenKhoa.Spam = !chuyenKhoa.Spam;
                    context.ChuyenKhoas.Update(chuyenKhoa);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

    }
}
