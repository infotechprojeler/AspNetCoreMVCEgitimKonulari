using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            // HttpContext.Request.Query["ReturnUrl"] : burada adres çubuğundaki ReturnUrl isimli QueryString nesnesini yakalayıp işleyebiliyoruz. Kullanıcıyı burada yer alan ekrana yönlendirmek için mesela.
            // HttpContext.Request.Query["UrunAdi"] : bu şekilde adres çubuğundan gönderilen ürün adını yakalayıp veritabanında eşleşen kayıtları bulup kullanıcıya ilgili ürünleri sunabiliriz.
            return View();
        }
    }
}
