using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC10FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? dosya)
        {
            if (dosya is not null)
            {
                var uzanti = Path.GetExtension(dosya.FileName).ToLower();
                string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/";
                var klasorVarmi = Directory.Exists(klasor);
                if (klasorVarmi == false)
                {
                    var sonuc = Directory.CreateDirectory(klasor);
                    TempData["Message"] = "Klasör Oluşturuldu : " + sonuc;
                }
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif" || uzanti == ".jfif" || uzanti == ".webp")
                {
                    // eğer izin verdiğimiz uzantıda bir dosya geldiyse yükleyebiliriz
                    using var stream = new FileStream(klasor + dosya.FileName, FileMode.Create);
                    dosya.CopyTo(stream);
                    TempData["Message"] = "Resim Yüklendi";
                    return RedirectToAction("Index");
                }
                else
                    TempData["Message"] = "Sadece Resim Dosyası Yükleyebilirsiniz!";
            }
            return View();
        }
        [HttpPost]
        public ActionResult ResimSil(string resimYolu)
        {
            var resimVarmi = System.IO.File.Exists(resimYolu); // bu metot kendisine verilen yolda bir dosya var mı yok mu  kontrol eder ve varsa true yoksa false döner
            if (resimVarmi == true) // eğer sunucuda resim varsa
            {
                System.IO.File.Delete(resimYolu); // resmi sunucudan sil
                return RedirectToAction("Index"); // ve tekrar sayfayı indexe yönlendir.
            }
            return View();
        }
    }
}
