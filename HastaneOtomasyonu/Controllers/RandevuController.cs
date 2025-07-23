using System;
using HastaneOtomasyonu.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace HastaneOtomasyonu.Controllers
{
    public class RandevuController : Controller
    {
        private ProjeContext db = new ProjeContext();

        // GET: Randevu
        // Randevu listeleme

        public ActionResult Index()
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            var randevular = db.Randevular
                               .Include(r => r.HastaId)
                               .Include(r => r.DoktorId)
                               .ToList();
            ViewBag.Hastalar = db.Hastalar.ToList();
            ViewBag.Doktorlar = db.Doktorlar.ToList();
            return View(randevular);
        }
        // Randevu ekleme (GET)
        public ActionResult Ekle()
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            ViewBag.HastaId = new SelectList(db.Hastalar, "Id", "Ad");
            ViewBag.DoktorId = new SelectList(db.Doktorlar, "Id", "Ad");
            return View();
        }

        // Randevu ekleme (POST)
        [HttpPost]
        public ActionResult Ekle(Randevular randevu)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            if (ModelState.IsValid)
            {
                db.Randevular.Add(randevu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HastaId = new SelectList(db.Hastalar, "Id", "Ad", randevu.HastaId);
            ViewBag.DoktorId = new SelectList(db.Doktorlar, "Id", "Ad", randevu.DoktorId);
            return View(randevu);
        }
        // Randevu silme
        public ActionResult Sil(int id)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            var randevu = db.Randevular.Find(id);
            db.Randevular.Remove(randevu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}