using System.ComponentModel.DataAnnotations;

namespace BlocoDeNotas.front.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
