using System.ComponentModel.DataAnnotations;

namespace web_api_health_clinic.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório !!!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório !!!")]
        public string? Senha { get; set; }
    }
}
