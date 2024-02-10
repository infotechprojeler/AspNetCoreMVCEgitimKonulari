using AspNetCoreMVCEgitimKonulari.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // .net core da kullanýcý giriþ sistemi kullanacaksak gerekli kütüphane

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// aþaðýdaki kod uyecontexti entity framework kullanabilmek için uygulamaya ekler.
builder.Services.AddDbContext<UyeContext>();

// Uygulamada session kullanýmýný aktif etmek için:
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/MVC15FiltersUsing/Login"; // oturum açmayan kullanýcýlarý varsayýlan account/login adresi yerine kendi istediðimiz login sayfasýna bu þekilde yönlendiriyoruz
    }
    ); // uygulamada cookie bazlý oturum sistemi kullanacaðýz

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // uygulama http den https ye yönlendirmeyi kullansýn
app.UseStaticFiles(); // app(uygulamamýz) statik (css, js, resim gibi) dosyalarý kullanabilsin

app.UseSession(); // uygulamanýn içinde session kullanýmýný aktif et

app.UseRouting(); // uygulamada routing kullanýlsýn

app.UseAuthorization(); // yetkilendirme kullanýlsýn

app.MapControllerRoute( // uygulamanýn kullanacaðý varsayýlan routing mekanizmasý
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // eðer controller ve action belirtilmezse varsayýlan olarak home index çalýþsýn

app.Run(); // yukardaki tüm yapýlandýrmalarý kullanarak uygulamayý çalýþtýr.
