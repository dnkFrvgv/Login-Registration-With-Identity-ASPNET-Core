using System.ComponentModel.DataAnnotations;

namespace authentication.Model
{
  public class Register
    {   [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username é obrigatório")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Senha tem que ter entre 6 e 20 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmar senha é obrigatória")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}