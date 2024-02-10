using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // .net core da kullan�c� giri� sistemi kullanacaksak gerekli k�t�phane

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// a�a��daki kod uyecontexti entity framework kullanabilmek i�in uygulamaya ekler.
builder.Services.AddDbContext<UyeContext>();

// Uygulamada session kullan�m�n� aktif etmek i�in:
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/MVC15FiltersUsing/Login"; // oturum a�mayan kullan�c�lar� varsay�lan account/login adresi yerine kendi istedi�imiz login sayfas�na bu �ekilde y�nlendiriyoruz
    }
    ); // uygulamada cookie bazl� oturum sistemi kullanaca��z

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

app.UseSession(); // uygulaman�n i�inde session kullan�m�n� aktif et

app.UseRouting(); // uygulamada routing kullan�ls�n

app.UseAuthorization(); // yetkilendirme kullan�ls�n

app.MapControllerRoute( // uygulaman�n kullanaca�� varsay�lan routing mekanizmas�
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er controller ve action belirtilmezse varsay�lan olarak home index �al��s�n

app.Run(); // yukardaki t�m yap�land�rmalar� kullanarak uygulamay� �al��t�r.
