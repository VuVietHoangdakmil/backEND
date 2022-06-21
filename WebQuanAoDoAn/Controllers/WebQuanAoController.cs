using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanAoDoAn.Models;

namespace WebQuanAoDoAn.Controllers
{
    public class WebQuanAoController : Controller
    {
        // GET: WebQuanAo
        DbWebQuanAoDataContext data = new DbWebQuanAoDataContext();
        // GET: WebQuanAo
        private List<SAN_PHAM> LaySanPhamMoi(int count)
        {
            return data.SAN_PHAMs.Take(count).ToList();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var sanpham = LaySanPhamMoi(20);
            return View(sanpham);
        }
        public ActionResult ALLsanpham()
        {
            var sanpham = LaySanPhamMoi(40);
            return View(sanpham);
        }
        public ActionResult Loaispcon()
        {

            var loaisp = from sp in data.LOAI_SPs select sp;
            return PartialView(loaisp);
        }

        public ActionResult SptheoLoai(int id)
        {
            var sanpham = from sp in data.SAN_PHAMs where sp.MA_LOAI == id select sp;

            return View(sanpham);


        }

        public ActionResult Detail(int id)
        {
            var sanpham = from sp in data.SAN_PHAMs where sp.MA_SP == id select sp;

            return View(sanpham.Single());


        }

        public ActionResult Size(int id)
        {
            var sizes = from size in data.KICH_THUOCs where size.MA_SP== id select size;

            return PartialView(sizes);


        }

        public ActionResult IMAGE(int id)
        {
            var images = from image in data.HINH_ANHs where image.MA_SP == id select image;

            return PartialView(images);

        }
    }
}