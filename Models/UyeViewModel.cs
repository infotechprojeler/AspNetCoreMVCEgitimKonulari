using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCEgitimKonulari.Models
{
    public class UyeViewModel
    {
        [EmailAddress(ErrorMessage = "Geçersiz Mail Girdiniz!"), StringLength(50)] // aşağıdaki alan tipi email olmalıdır
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        public string Email { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} {2} Karakterden Az Olamaz", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} Alanı Boş Bırakılamaz!")]
        public string Sifre { get; set; }
    }
}
