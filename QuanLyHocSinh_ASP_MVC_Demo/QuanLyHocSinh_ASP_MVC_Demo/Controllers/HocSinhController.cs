using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Controllers
{
    public class HocSinhController : Controller
    {

        public IActionResult Index()
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var listHocSinh = context.HocSinhs.Include(x => x.MaKhoaNavigation).ToList();
                //var data1 = context.ChuyenKhoas.ToList();
                //ViewBag.ChuyenKhoas = data1;
                return View(listHocSinh);
            }
        }

        public IActionResult AddHocSinh(int mess = 1)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var data = context.ChuyenKhoas.Where(x=>x.Spam == true).ToList();
                ViewBag.ChuyenKhoas = data;

                ViewBag.Mess = mess;
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddHocSinh(HocSinh hocSinh)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {

                
                try
                {
                    ChuyenKhoa chuyenKhoa = context.ChuyenKhoas.FirstOrDefault(x=> x.MaKhoa == hocSinh.MaKhoa && x.Spam == true);
                    if(chuyenKhoa != null)
                    {
                        context.HocSinhs.Add(hocSinh);
                        if (context.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                        
                }catch(Exception ex)
                {
                    
                }
               
                return RedirectToAction("AddHocSinh");

            }
        }

        public IActionResult UpdateHocSinh(string id)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var listChuyenKhoa = context.ChuyenKhoas.Where(x=>x.Spam == true).ToList();
                ViewBag.ChuyenKhoas = listChuyenKhoa;

                var hocSinh = context.HocSinhs.FirstOrDefault(x=>x.MaSv.Equals(id));
                return View(hocSinh);
            }
        }

        [HttpPost]
        public IActionResult UpdateHocSinh(HocSinh hocSinh)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                context.HocSinhs.Update(hocSinh);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("UpdateHocSinh");
                }
               
            }
        }

        public IActionResult DeleteHocSinh(string id)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var hocSinh = context.HocSinhs.Include(x=>x.DiemThis).FirstOrDefault(x => x.MaSv.Equals(id));
                if(hocSinh != null)
                {
                    foreach (DiemThi item in hocSinh.DiemThis)
                    {
                        List<DiemThi> listDiemThi = context.DiemThis.Where(x => x.MaSv.Equals(item.MaSv)).ToList();
                        if(listDiemThi.Count() > 0)
                        {
                            context.DiemThis.RemoveRange(listDiemThi);
                            context.SaveChanges();
                        }
                    }
                }
                context.HocSinhs.Remove(hocSinh);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult DetailHocSinh(string id)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var hocSinh = context.HocSinhs.Include(x=>x.MaKhoaNavigation).FirstOrDefault(x=>x.MaSv.Equals(id));
                return View(hocSinh);
            }
        }

        public void ShowMessage(string message)
        {
            TempData["Message"] = message;
        }
        public IActionResult SpamHocSinh(string id)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var hocSinh = context.HocSinhs.FirstOrDefault(x => x.MaSv.Equals(id));
                if (hocSinh != null)
                {
                    hocSinh.Spam = ! hocSinh.Spam;
                    if(hocSinh.Spam == true)
                    {
                        ShowMessage("Active Ok");
                    }
                    if(hocSinh.Spam == false)
                    {
                        ShowMessage("Locked Hoc Sinh Ok");
                    }
                    context.HocSinhs.Update(hocSinh);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}
