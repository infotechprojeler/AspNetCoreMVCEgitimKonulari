using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC09ViewResultsController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult FarkliViewDondur()
        {
            return View("Index"); // normalde Views > MVC09ViewResults altında FarkliViewDondur isminde bir cshtml sayfası açmamız gerekir fakat buradaki gibi View("Index") yazarsak FarkliViewDondur e gelen istekte ekrana index sayfası getirilir.
        }
        public ActionResult Yonlendir()
        {
            // return Redirect("/Home/Contact"); // uygulama içindeki bir sayfaya
            return Redirect("https://www.google.com.tr/"); // dış bağlantıya
        }
        public ActionResult ActionaYonlendir()
        {
            // return RedirectToAction("Index"); // Index action ına yönlendir
            // return RedirectToAction("Yonlendir"); // Yonlendir action ına yönlendir
            return RedirectToAction("Contact", "Home"); // Home controller daki  Contact action ına yönlendir
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Contact", id = 18 }); // route yazarak yönlendirme
        }
        public PartialViewResult KategorileriGetirPartial() // bu actiona istek gelirse
        {
            return PartialView("_KategorilerPartial"); // geriye bir partial view döndürür
        }
        public PartialViewResult ModellePartialGetir() // bu actiona istek gelirse
        {
            var uyeListesi = context.Uyeler.ToList(); // partial view a göndermemiz gereken model olan üye listesini çektik
            return PartialView("_PartialModelKullanimi", uyeListesi); // geriye bir partial view döndürür. 2. parametre olarak view lara model datası yollayabiliyoruz.
        }
        //public JavaScriptResult JsResult() .net core da kaldırıldı
        //{
        //    return JavaScript("console.log('Bu yazı JavaScriptResult ile gönderildi')");
        //}
        public JsonResult JsonResult()
        {
            var uyeListesi = context.Uyeler.ToList();
            return Json(uyeListesi); // varsayılan olarak json get istekleri kapalıdır, açmak için 2. parametreyi ekliyoruz.
        }
        public ContentResult XmlContentResult()
        {
            var uyeListesi = context.Uyeler.ToList();
            var xml = "<kullanicilar>";
            foreach (var item in uyeListesi)
            {
                xml += $@"<kullanici>
                            <Id>{item.Id}</Id>
                            <Ad>{item.Ad}</Ad>
                            <Soyad>{item.Soyad}</Soyad>
                            <KullaniciAdi>{item.KullaniciAdi}</KullaniciAdi>
                            <Email>{item.Email}</Email>
                        </kullanici>";
            }
            xml += "</kullanicilar>";
            return Content(xml, "application/xml");
        }
    }
}
