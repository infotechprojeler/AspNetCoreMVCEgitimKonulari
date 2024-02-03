using AspNetCoreMVCEgitimKonulari.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// aþaðýdaki kod uyecontexti entity framework kullanabilmek için uygulamaya ekler.
builder.Services.AddDbContext<UyeContext>();

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

app.UseRouting(); // uygulamada routing kullanýlsýn

app.UseAuthorization(); // yetkilendirme kullanýlsýn

app.MapControllerRoute( // uygulamanýn kullanacaðý varsayýlan routing mekanizmasý
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // eðer controller ve action belirtilmezse varsayýlan olarak home index çalýþsýn

app.Run(); // yukardaki tüm yapýlandýrmalarý kullanarak uygulamayý çalýþtýr.
