using ControleDeEstoque.Models;

namespace ControleDeEstoque.Repository
{
    public interface ISectionRepository
    {
        void AddSection(UsersModel user);
        UsersModel SearchSection();
        void DeleteSection();
    }
}
