using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCEgitimKonulari.Models
{
    public class UyeContext : DbContext // .net core da uygulamada kullanacağımız dbcontext i program.cs dosyasında tanıtmamız gerekiyor!
    {
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // bu metot veritabanı ayarlarını yapılandırmamızı sağlıyor.
             optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=UyeDb; integrated security=True; trustservercertificate=True;"); // burada sql server veritabanı kullanmak istediğimizi belirttik. içerisine connection string yollamalıyız!

            // connection stringi appsettins.json dan çekmek için
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //var connectionString = configuration.GetConnectionString("UyeContext");

            //optionsBuilder.UseSqlServer(connectionString);

            //base.OnConfiguring(optionsBuilder);
        }
    }
}
