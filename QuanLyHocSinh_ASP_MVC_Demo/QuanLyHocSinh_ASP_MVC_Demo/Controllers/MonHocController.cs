using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyHocSinh_ASP_MVC_Demo.Models;

namespace QuanLyHocSinh_ASP_MVC_Demo.Controllers
{
    public class MonHocController : Controller
    {
        public IActionResult Index()
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var listMonHoc = context.MonHocs.ToList();
                return View(listMonHoc);
            }

        }

        public IActionResult AddMonHoc()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMonHoc(MonHoc monHoc)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                context.MonHocs.Add(monHoc);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("AddMonHoc");
                }
            }
        }

        public IActionResult UpdateMonHoc(int maMonHoc)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var monHoc = context.MonHocs.FirstOrDefault(x => x.MaMh == maMonHoc);
                return View(monHoc);
            }

        }

        [HttpPost]
        public IActionResult UpdateMonHoc(MonHoc monHoc)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            { 
                context.MonHocs.Update(monHoc);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("UpdateMonHoc");
                }
            }
        }

        public IActionResult DetailMonHoc(int maMonHoc)
        {
            using (QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var monHoc = context.MonHocs.FirstOrDefault(x => x.MaMh == maMonHoc);
                return View(monHoc);
            }

        }
        public IActionResult DeleteMonHoc(int maMonHoc)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                MonHoc monHoc = context.MonHocs.Include(x=>x.DiemThis).FirstOrDefault(x=>x.MaMh== maMonHoc);
                try
                {
                    if(monHoc != null)
                    {
                        if (monHoc.DiemThis.Count() > 0)
                        {
                            foreach(DiemThi item in monHoc.DiemThis)
                            {
                                List<DiemThi> listDiemThi = context.DiemThis.Where(x=>x.MaMh == item.MaMh).ToList();
                                if (listDiemThi.Count() > 0)
                                {
                                    context.DiemThis.RemoveRange(listDiemThi);
                                    context.SaveChanges();

                                }
                            }
                        }
                        context.MonHocs.Remove(monHoc);
                        context.SaveChanges();
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return RedirectToAction("Index");    
            }
        }

        public IActionResult SapmMonHoc(int maMonHoc)
        {
            using(QuanLyHocSinhContext context = new QuanLyHocSinhContext())
            {
                var monHoc = context.MonHocs.FirstOrDefault(x => x.MaMh == maMonHoc);
                if(monHoc != null)
                {
                    monHoc.Spam = !monHoc.Spam;
                    context.MonHocs.Update(monHoc);
                    context.SaveChanges(true);
                }
                return RedirectToAction("Index");
            }
        }
    }
}
