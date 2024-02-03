using AspNetCoreMVCEgitimKonulari.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// a�a��daki kod uyecontexti entity framework kullanabilmek i�in uygulamaya ekler.
builder.Services.AddDbContext<UyeContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // uygulama http den https ye y�nlendirmeyi kullans�n
app.UseStaticFiles(); // app(uygulamam�z) statik (css, js, resim gibi) dosyalar� kullanabilsin

app.UseRouting(); // uygulamada routing kullan�ls�n

app.UseAuthorization(); // yetkilendirme kullan�ls�n

app.MapControllerRoute( // uygulaman�n kullanaca�� varsay�lan routing mekanizmas�
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er controller ve action belirtilmezse varsay�lan olarak home index �al��s�n

app.Run(); // yukardaki t�m yap�land�rmalar� kullanarak uygulamay� �al��t�r.
