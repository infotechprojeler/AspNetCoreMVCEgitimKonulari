namespace AspNetCoreMVCEgitimKonulari.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Name { get; set; } // .net core da string alanlar non nullable-boş geçilemez hale getirildi o yüzden yeşil tırtık çıkıyor
        public string? Description { get; set; } // string bir alanı nullable-boş geçilebilir yapmak için ? ekliyoruz
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
