using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ControleDeEstoque.Helper;

namespace ControleDeEstoque.Models
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<ProductsModel> Products { get; set; }

        public void SetPassword()
        {
            Password = Password.Encrypt();
        }
    }
}
