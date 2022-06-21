using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanAoDoAn.Models;

namespace WebQuanAoDoAn.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        DbWebQuanAoDataContext data = new DbWebQuanAoDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        //dangky
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACH_HANG kh)
        {

            var hoten = collection["hoten"];
            var mail = collection["email"];
            var SDT = collection["SDT"];
            var mk = collection["pwd-signup"];
            var nlmk = collection["pwd-signup-again"];
            KHACH_HANG khS = data.KHACH_HANGs.FirstOrDefault(n => n.EMAIL == mail);
            if (khS == null)
            {
                kh.TEN_KH = hoten;
                kh.MK_DN = mk;
                kh.EMAIL = mail;
                kh.SDT = SDT;
                kh.TEN_DN = mail;
                data.KHACH_HANGs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("Index", "WebQuanAo");
               
            }
            else
            {

                ViewBag.ThongBao = "Email đã có người đăng kí";
            }

            return this.Dangky();
        }
        //dang nhap
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["txt-signin"];
            var matkhau = collection["pwd"];
            KHACH_HANG kh = data.KHACH_HANGs.SingleOrDefault(n => n.TEN_DN == tendn && n.MK_DN == matkhau);
            if (kh != null)
            {
                ViewBag.Thongbao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.Thongbao = "Sai tên đăng nhập";
            }
            return View();
        }
    
    }
}