using AspNetCoreMVCEgitimKonulari.Filters;
using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            TempData["Kullanici"] = HttpContext.Session.GetString("userguid");
            return View();
        }
        [UserControl] // FiltreKullanimi action ı çalıştığında usercontrol çalışır
        public ActionResult FiltreKullanimi()
        {
            return RedirectToAction("Index");
        }
        [Authorize] // Authorize attribute ü altındaki action ı oturum açılmamışsa korur ve ekranın açılmasını engeller. Bunu kullanabilmek için web.config dosyasına authentication kodunu ekliyoruz.
        public ActionResult UyeGuncelle(int? id)
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return BadRequest(); // geriye geçersiz istek hatası döndür.
            }
            Uye uye = context.Uyeler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (uye == null) // eğer db de kayıt bulamazsan
                return NotFound(); // geriye not found - kayıt bulunamadı ekranı göster
            return View(uye);
        }
        [HttpPost]
        public IActionResult UyeGuncelle(Uye uye)
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Uye uye)
        {
            try
            {
                Uye admin = context.Uyeler.Find(uye.Email, uye.Sifre);
                if (admin is not null)
                {
                    ModelState.AddModelError("", "Merhaba Admin");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(uye);
        }
    }
}
