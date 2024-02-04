using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCEgitimKonulari.Controllers
{
    public class MVC06CRUDController : Controller
    {
        // UyeContext context = new UyeContext();
        private readonly UyeContext _context; // Dependency injection ile kullanmak için
        // yukardaki tanımlamayı yaptıktan sonra _context a sağ tıklayıp açılan menüden ampule tıklayıp açılan menüden generate constructor diyerek aşağıdaki kurucu metodu oluşturuyoruz
        public MVC06CRUDController(UyeContext context) // bu metottaki context nesnesini sistem algıladığında new leme işlemini otomatik olarak yapar
        {
            _context = context; // sistemin new lediği nesneyi yukardaki boş olanı doldurmak için kullanırız ve böylece bu controllerdaki tüm metotlarda _context ile veritabanı işlemleri yapabiliriz.
        }

        // .net core da veritabanına bağlanmak için uyecontext classında connectionstring i ayarlamamız gerekiyor.
        public async Task<IActionResult> Index(string q = "") // metot Task haline gelir
        {
            //var model = context.Uyeler.ToList(); // verileri veritabanından senkron olarak çekme
            var asenkronModel = await _context.Uyeler.Where(u => u.Ad.Contains(q) || u.Soyad.Contains(q)).ToListAsync(); // verileri veritabanından asenkron olarak çekme. asenkron metotlar çağrılırken başa await kelimesi eklenmelidir!
                                                                     // İçerisinde await kullanılan bir metot da mutlaka asenkron olmalıdır!
                                                                     // Bir metodu asenkron hale getirmek için altı kızaran metodun üzerine gelip ampul üzerinden make method async menüsüne tıklayabilir veya elle manuel olarak kodları ekleyebiliriz.
                                                                     // Eğer metodun üzerine geldiğimizde ampul çıkmazsa metot adına sağ tıklayıp quick action refactorineg menüsünden yapabiliriz
                                                                     // Ayrıca await yazdığımızda metoda eklenen async kelimesini silerek de işlemleri tekrar yapabiliriz.
            return View(asenkronModel);
        }
        public ActionResult Create() // yeni kayıt ekleme sayfası
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Uye uye) // yeni kayıt ekleme sayfası
        {
            if (ModelState.IsValid)
            {
                // _context.Uyeler.Add(uye); senkron kayıt ekleme metodu
                // int sonuc = _context.SaveChanges(); // SaveChanges metodu bize veritabanında etkilenen kayıt sayısını döndürür.
                await _context.Uyeler.AddAsync(uye); // asenkron kayıt ekleme metodu
                int sonuc = await _context.SaveChangesAsync(); // asenkron kayıt
                if (sonuc > 0) // eğer kayıt eklendiyse 1 değeri döner
                {
                    return RedirectToAction("Index");
                }
            }
            return View(uye);
        }
        public async Task<ActionResult> Edit(int? id) // kayıt düzenleme sayfası
        {
            if (id is null)
                return BadRequest();
            // senkron olarak datayı çekme
            // var model = _context.Uyeler.Find(id);
            // Asenkron olarak datayı çekme
            var model = await _context.Uyeler.FindAsync(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int? id, Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Uyeler.Update(uye); // not: update metodunun asenkronu yok!
                int sonuc = await _context.SaveChangesAsync(); // asenkron kayıt
                if (sonuc > 0) // eğer kayıt eklendiyse 1 değeri döner
                {
                    return RedirectToAction("Index");
                }
            }
            return View(uye);
        }
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            var model = await _context.Uyeler.FindAsync(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int? id, Uye uye)
        {
            _context.Uyeler.Remove(uye); // Silme metodunun da asenkronu yok!
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
