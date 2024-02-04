using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC08PartialController : Controller
    {
        UyeContext context = new UyeContext();
        // GET: MVC08Partial
        public ActionResult Index()
        {
            return View(context.Uyeler.ToList());
        }
    }
}
