using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC06CRUDController : Controller
    {
        UyeContext context = new UyeContext();
        // .net core da veritabanına bağlanmak için uyecontext classında connectionstring i ayarlamamız gerekiyor.
        public IActionResult Index()
        {
            var model = context.Uyeler.ToList();
            return View(model);
        }
        public ActionResult Create() // yeni kayıt ekleme sayfası
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Uye uye) // yeni kayıt ekleme sayfası
        {
            return View();
        }
    }
}
