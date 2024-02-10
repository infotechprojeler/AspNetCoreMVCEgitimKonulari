using System.Text.Json;

namespace AspNetCoreMVCEgitimKonulari.Extensions
{
    // c# ta sistemde bulunmayan özellikleri extension metotlar yazarak kullanabiliyoruz.
    // Sessionda nesne saklama kaldırılmış fakat json verisi saklayabilmekteyiz, bunun için de bir eklenti yazmamız gerekli.
    public static class SessionExtension // eklenti classlarını static olarak işaretliyoruz!
    {
        public static void SetJson(this ISession session, string key, object value) // static classlarda static işaretli metot kullanıyoruz!
        {
            // this ISession session bölümü .net in session yapısını kullanarak genişletme yapacağız anlamına geliyor
            session.SetString(key, JsonSerializer.Serialize(value)); // Burada uygulamadaki session yapısına key ile belirlenen isimde object olarak her türlü veriyi alıp JsonSerializer.Serialize metoduyla nesneyi json tipine çevirip session da saklıyoruz.
        }
        public static T? GetJson<T>(this ISession session, string key) where T : class // Burada getjson metodu dışarıdan alacağı key deki session a ulaşıp içindeki datayı JsonSerializer.Deserialize metoduyla json dan nesneye çeviriyor. where T : class bölümü ise T nesnesinin class tipinde olması şartını bildiriyor.
        {
            var data = session.GetString(key);
            return data == null ? default : JsonSerializer.Deserialize<T>(data);
        }
    }
}
