using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreMVCEgitimKonulari.Filters
{
    public class UserControl : ActionFilterAttribute // Bir classın filtre olarak çalışabilmesi için ActionFilterAttribute classından miras almamız gerek
    {
        // override filtre için kullanılabilecek metotları görebilmemizi sağlayan anahtar kelime
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // bu filtrenin kullanılacağı action çalıştırılmak istendiğinde bu metot çalışır.
            base.OnActionExecuted(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // bu filtrenin kullanılacağı action çalıştırıldığında bu metot çalışır.
            var UserGuid = context.HttpContext.Session.GetString("userguid"); // o anda çalışan uygulamadaki sessionda istediğimiz değeri yakalıyoruz
            var userGuid = context.HttpContext.Request.Cookies["userguid"]; // UserGuid isimli cookie yi yakalıyoruz
            if (UserGuid == null) // session veye cookie boşsa
            {
                context.Result = new RedirectResult("/MVC12Session?msg=ErisimEngellendi");
            }
            base.OnActionExecuting(context);
        }
    }
}
