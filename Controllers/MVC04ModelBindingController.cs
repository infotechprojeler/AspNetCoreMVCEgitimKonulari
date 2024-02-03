using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC04ModelBindingController : Controller
    {
        // GET: MVC04ModelBinding
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KullaniciDetay() // Bir action metodunun varsayılan çalışma yöntemi httpget dir, bu yüzden metodun üzerine bu attribute ü eklemeye gerek yoktur.
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "muro@vadi.co",
                KullaniciAdi = "murat",
                Sifre = "1234"
            }; // kullanıcıyı oluşturduk

            ViewBag.KullaniciAdSoyad = kullanici.Ad + " " + kullanici.Soyad;

            return View(kullanici); // burada view içerisine yukardaki kullanıcıyı göndermezsek ekranda bu bilgilere ulaşamayız!
        }
        [HttpPost]
        public ActionResult KullaniciDetay(Kullanici kullanici) // bu şekilde view ekranında kullanılan model classını yakalayıp içindeki verilere ulaşabiliyoruz, buna mvc de model binding deniliyor.
        {
            // burada artık yakaladığımız kullanici nesnesini veritabanına kaydedebilir, güncelleyebilir veya silebiliriz.
            return View(kullanici); // gelen yeni kullanıcı bilgisini tekrardan view ekranına yolluyoruz.
        }
        public ActionResult AdresDetay()
        {
            Adres adres = new Adres();
            adres.Sehir = "İstanbul";
            adres.Ilce = "Şişli";
            adres.AcikAdres = "Mecidiyeköyü";
            return View(adres);
        }
        [HttpPost]
        public ActionResult AdresDetay(Adres adres)
        {
            return View(adres);
        }
        public ActionResult KullaniciAdresDetay()
        {
            var model = new KullaniciAdresDetayViewModel();

            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "muro@vadi.co",
                KullaniciAdi = "murat",
                Sifre = "1234"

            };
            Adres adres = new Adres();
            adres.Sehir = "İstanbul";
            adres.Ilce = "Şişli";
            adres.AcikAdres = "Mecidiyeköyü";

            model.Adres = adres;
            model.Kullanici = kullanici;

            return View(model);
        }
    }
}
