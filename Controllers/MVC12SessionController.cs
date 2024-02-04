using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC12SessionController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre); // üyeler tablosunda formdan gönderilen kullanıcı adı ve şifreyle eşleşen 1 kayıt var mı?
            if (kullanici != null) // eğer kullanıcı db de varsa
            {
                /* .net core da bu şekilde session tanımlama kaldırıldı!
                Session["deger"] = "Admin"; // adı deger olan bir session oluştur
                Session["userguid"] = Guid.NewGuid().ToString();
                Session["kullanici"] = kullanici; // session obje alabildiği için her türlü veri yükleyebiliyoruz
                */
                // artık bu şekilde session oluşturabiliyoruz
                // .net core da session da sadece int ve string tipinde veri saklayabiliyoruz.
                HttpContext.Session.SetString("kullanici", kullaniciAdi);
                HttpContext.Session.SetString("sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1);
                HttpContext.Session.SetString("userguid", Guid.NewGuid().ToString());
                return RedirectToAction("SessionOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>Giriş Başarısız!</div>";
            return View("Index");
        }
        public ActionResult SessionOku()
        {
            // Session daki değerleri okumak için GetString ve getint32 metotları kullanılıyor
            TempData["SessionBilgi"] = HttpContext.Session.GetString("userguid"); // deger isimli session ın üzerindeki veriyi tempdataya aktar
            return View();
        }
        public ActionResult SessionSil()
        {
            HttpContext.Session.Remove("userguid"); // userguid isimli session ı sil
            HttpContext.Session.Clear(); // tüm sessionları sil
            return RedirectToAction("Index");
        }
    }
}
