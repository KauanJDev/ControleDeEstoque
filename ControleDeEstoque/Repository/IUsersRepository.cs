using ControleDeEstoque.Models;

namespace ControleDeEstoque.Repository
{
    public interface IUsersRepository
    {
        UsersModel Register(string name, string email, string password);
        UsersModel Login(string email, string password);
        UsersModel ResetPassword(string email,string password, string newPassword);
    }
}
