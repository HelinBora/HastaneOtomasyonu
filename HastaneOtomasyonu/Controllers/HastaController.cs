using HastaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace HastaneOtomasyonu.Controllers
{
    public class HastaController : Controller
    {
        private ProjeContext db = new ProjeContext();
        // GET: Hasta
        // Hasta listeleme 
        public ActionResult Index()
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            var hastalar = db.Hastalar.ToList();

            return View();
        }
        // Hasta ekleme formu  
        public ActionResult Ekle()
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            return View();
        }
        // Hasta ekleme işlemi  
        [HttpPost]
        public ActionResult Ekle(Hastalar Hastalar)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            if (ModelState.IsValid)
            {
                Hastalar hasta = db.Hastalar.Add(Hastalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Hastalar);
        }
        // Hasta düzenleme formu  
        public ActionResult Duzenle(int id)
        {
            var hasta = db.Hastalar.Find(id);
            return View(hasta);
        }

        // Hasta güncelleme işlemi  
        [HttpPost]
        public ActionResult Duzenle(Hastalar hasta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hasta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hasta);
        }
        // Hasta silme  
        public ActionResult Sil(int id)
        {
            var hasta = db.Hastalar.Find(id);
            db.Hastalar.Remove(hasta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}