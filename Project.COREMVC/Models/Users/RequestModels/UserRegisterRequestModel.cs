using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.Users.RequestModels
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [Display(Name = "Kullanıcı Ismi")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email Formatında Giriş Yapınız")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [MinLength(8, ErrorMessage = "Minimum 6 karakter girilmesi gereklidir")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
