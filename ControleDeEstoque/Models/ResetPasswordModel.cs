using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Models
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "A nova senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
