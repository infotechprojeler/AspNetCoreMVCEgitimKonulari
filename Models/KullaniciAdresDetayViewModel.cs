namespace AspNetCoreMVCEgitimKonulari.Models
{
    public class KullaniciAdresDetayViewModel
    {
        // 1 ekranda 1 den fazla model class ı kullanmak istersek bu şekilde 1 class oluşturup içerisine property olarak kullanmak istediğimiz class ları tanımlıyoruz.
        public Kullanici Kullanici { get; set; }
        public Adres Adres { get; set; }
    }
}
