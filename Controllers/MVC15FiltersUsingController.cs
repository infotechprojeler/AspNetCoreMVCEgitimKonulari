using AspNetCoreMVCEgitimKonulari.Filters;
using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> LoginAsync(Uye uye)
        {
            try
            {
                // Uye admin = context.Uyeler.FirstOrDefault(u=>u.Email == uye.Email && u.Sifre == uye.Sifre); // 1.yöntem
                Uye admin = context.Uyeler.Where(u => u.Email == uye.Email && u.Sifre == uye.Sifre).FirstOrDefault(); // 2.yöntem
                if (admin is not null)
                {
                    // ModelState.AddModelError("", "Merhaba " + admin.Ad);
                    // Kullanıcıya giriş için vermek istediğimiz hakları tanımlıyoruz
                    var haklar = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, admin.Email),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    // kullanıcıya kimlik tanımlıyoruz
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcıya tanıdığımız hakları kimliğe işliyoruz
                    // kullanıcıya verdiğimiz kimlik ile tanımlı kurallardan oluşan nesne oluşturuyoruz
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi);
                    // Yetkilendirme ile sisteme girişi yapıyoruz
                    await HttpContext.SignInAsync(claimsPrincipal);
                    // Giriş sonrası tarayıcıda returnurl varsa 
                    if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]))
                    {
                        return Redirect(HttpContext.Request.Query["ReturnUrl"]); // kullanıcıyı ReturnUrl deki gitmek istediği adrese yönlendir
                    }
                    return RedirectToAction("Index"); // ReturnUrl yoksa anasayfaya yönlendir
                }
             }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(uye);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
