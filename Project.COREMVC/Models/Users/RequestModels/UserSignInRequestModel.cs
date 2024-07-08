using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.Users.RequestModels
{
    public class UserSignInRequestModel
    {
        [Required(ErrorMessage = "Kullanıcı ismi zorunludur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Sifre alanı zorunludur")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
