using ControleDeEstoque.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ControleDeEstoque.Repository
{
    public interface IProductRepository
    {
        ProductsModel AddProduct(string name, float price, int quantity, int userId);
        ProductsModel UpdateProduct(int id, string name, float price, int quantity);
        ProductsModel UpdateProduct(int id, string name, float price, int quantity, int userId);
        void DeleteProduct(int id);
        List<ProductsModel> SearchAllProducts(int userId);
    }
}
