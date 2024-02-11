using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCEgitimKonulari.ViewComponents
{
    public class Uyeler : ViewComponent
    {
        private readonly UyeContext _context;

        public Uyeler(UyeContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Uyeler.ToListAsync()); // geriye view ekranı dönüyoruz
        }
    }
}
