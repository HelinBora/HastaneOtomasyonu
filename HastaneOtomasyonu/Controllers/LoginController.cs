using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HastaneOtomasyonu.Models;
using System.Web.Mvc;

namespace HastaneOtomasyonu.Controllers
{
    public class LoginController : Controller
    {
        private ProjeContext db = new ProjeContext();

        // GET: Login
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(string email, string sifre)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(k => k.Email == email && k.Sifre == sifre);

            if (kullanici != null)
            {
                Session["kullanici"] = kullanici.Email;
                return RedirectToAction("Index", "Hasta");
            }
            else
            {
                ViewBag.Hata = "Geçersiz giriş bilgileri!";
                return View();
            }
        }

        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Giris");
        }
    }
}