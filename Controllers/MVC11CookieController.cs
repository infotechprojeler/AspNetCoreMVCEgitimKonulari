using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC11CookieController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = context.Uyeler.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre); // üyeler tablosunda formdan gönderilen kullanıcı adı ve şifreyle eşleşen 1 kayıt var mı?
            if (kullanici != null) // eğer girilen bilgilerle eşleşen bir kayıt varsa
            {
                // tarayıcıda 1 cookie oluştur
                CookieOptions cookieOptions = new() // oluşacak cookie ayarlarını yapılandırmak istersek bunu kullanıyoruz
                {
                    Expires = DateTime.Now.AddMinutes(1),
                };
                Response.Cookies.Append("kullaniciAdi", kullaniciAdi, cookieOptions); // çerezi kaydet
                Response.Cookies.Append("sifre", sifre, cookieOptions); // çerezi kaydet
                HttpContext.Response.Cookies.Append("userguid", Guid.NewGuid().ToString()); // userguid isminde 1 çerez daha oluştur ve içinde o kullanıcıya özel şifreli bir değer sakla
                return RedirectToAction("CookieOku");
            }
            else
                TempData["Mesaj"] = @"<div class='alert alert-danger'>
                    Giriş Başarısız!
                </div>";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (Request.Cookies["userguid"] is null)
            {
                TempData["Mesaj"] = @"<div class='alert alert-warning'>
                    Giriş Engellendi!
                </div>";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult CookieSil()
        {
            Response.Cookies.Delete("kullaniciAdi");
            Response.Cookies.Delete("sifre");
            Response.Cookies.Delete("userguid");
            return RedirectToAction("CookieOku");
        }
    }
}
