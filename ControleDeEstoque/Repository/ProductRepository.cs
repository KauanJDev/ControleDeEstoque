using ControleDeEstoque.Models;
using System.Linq;

namespace ControleDeEstoque.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ControleDeEstoque.DataContext.AppDbContext _context;
        public ProductRepository(ControleDeEstoque.DataContext.AppDbContext context)
        {
            _context = context;
        }

        public ProductsModel AddProduct(string name, float price, int quantity, int userId)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || price <= 0 || quantity < 0)
                {
                    throw new InvalidOperationException("Todos os campos são obrigatórios e devem ser válidos!");
                }
                if (_context.Products.Any(p => p.Name == name && p.UserId == userId))
                {
                    throw new InvalidOperationException("Já existe um produto com esse nome para este usuário!");
                }
                var product = new ProductsModel
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    UserId = userId
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ocorreu um erro ao adicionar o produto: " + ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new InvalidOperationException("Produto não encontrado!");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<ProductsModel> SearchAllProducts(int userId)
        {
            return _context.Products.Where(p => p.UserId == userId).ToList();
        }

        public ProductsModel UpdateProduct(int id, string name, float price, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;

            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public ProductsModel UpdateProduct(int id, string name, float price, int quantity, int userId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;

            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
