using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
