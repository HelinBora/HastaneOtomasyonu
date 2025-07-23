using System;
using HastaneOtomasyonu.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HastaneOtomasyonu.Controllers
{
    public class DoktorController : Controller
    {
        private ProjeContext db = new ProjeContext();

        // GET: Doktor
        // Listeleme
        public ActionResult Index()
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            var doktorlar = db.Doktorlar.Include(d => d.Branslar).ToList();

            return View();
        }
        // Ekle (GET)
        public ActionResult Ekle()
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            ViewBag.BransId = new SelectList(db.Branslar, "Id", "Ad");
            return View();
        }

        // Ekle (POST)
        [HttpPost]
        public ActionResult Ekle(Doktorlar doktor)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            if (ModelState.IsValid)
            {
                db.Doktorlar.Add(doktor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BransId = new SelectList(db.Branslar, "Id", "Ad", doktor.BransId);
            return View(doktor);
        }
        // Düzenle (GET)
        public ActionResult Duzenle(int id)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            var doktor = db.Doktorlar.Find(id);
            ViewBag.BransId = new SelectList(db.Branslar, "Id", "Ad", doktor.BransId);
            return View(doktor);
        }

        // Düzenle (POST)
        [HttpPost]
        public ActionResult Duzenle(Doktorlar doktor)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            if (ModelState.IsValid)
            {
                db.Entry(doktor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BransId = new SelectList(db.Branslar, "Id", "Ad", doktor.BransId);
            return View(doktor);
        }
        // Sil
        public ActionResult Sil(int id)
        {
            if (Session["kullanici"] == null)
                return RedirectToAction("Giris", "Login");
            var doktor = db.Doktorlar.Find(id);
            db.Doktorlar.Remove(doktor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}