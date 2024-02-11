using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC17ViewComponentController : Controller
    {
        private readonly UyeContext _context;

        public MVC17ViewComponentController(UyeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // return View(await _context.Uyeler.ToListAsync()); // datayı buradan yollamak istersek
            return View();
        }
    }
}
