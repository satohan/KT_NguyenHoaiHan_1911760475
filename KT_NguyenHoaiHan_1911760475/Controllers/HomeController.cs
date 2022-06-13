using KT_NguyenHoaiHan_1911760475.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KT_NguyenHoaiHan_1911760475.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {                      
                var all_sinhvien = from ss in data.SinhViens select ss;
                return View(all_sinhvien);   
            
        }


        public ActionResult About()
        {
            var all_Hocphan = from HP in data.HocPhans select HP;
            return View(all_Hocphan);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_ID = collection["id"];
            var E_Hoten = collection["Hoten"];
            var E_GioiTinh = collection["gioitinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_Hinh = collection["hinh"];
            var E_MaNganh = collection["manganh"];
            if (string.IsNullOrEmpty(E_Hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {

                s.HoTen = E_Hoten.ToString();
                s.GioiTinh = E_GioiTinh.ToString();
                s.NgaySinh = E_NgaySinh;
                s.Hinh = E_Hinh;
                s.MaNganh = E_MaNganh;
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_Sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_Sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_Id = data.SinhViens.First(m => m.MaSV == id);
            var E_Hoten = collection["Hoten"];
            var E_GioiTinh = collection["gioitinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_Hinh = collection["hinh"];
            var E_MaNganh = collection["manganh"];
            E_Id.MaSV = id;
            if (string.IsNullOrEmpty(E_Hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_Id.HoTen = E_Hoten;
                E_Id.GioiTinh = E_GioiTinh;
                E_Id.NgaySinh = E_NgaySinh;
                E_Id.Hinh = E_Hinh;
                E_Id.MaNganh = E_MaNganh;
                UpdateModel(E_Id);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sach = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
    }
}