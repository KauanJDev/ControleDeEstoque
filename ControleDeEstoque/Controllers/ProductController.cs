using ControleDeEstoque.Repository;
using Microsoft.AspNetCore.Mvc;
using ControleDeEstoque.Models;

namespace ControleDeEstoque.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IUsersRepository usersRepository, ISectionRepository sectionRepository, IProductRepository productRepository)
        {
            _usersRepository = usersRepository;
            _sectionRepository = sectionRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var user = _sectionRepository.SearchSection();
            List<ProductsModel> product = _productRepository.SearchAllProducts(user.Id);
            return View(product);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                TempData["SuccessMessage"] = "Produto excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao excluir produto: " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddProduct(string name, float price, int quantity)
        {
            try
            {
                var user = _sectionRepository.SearchSection();
                if (user == null)
                {
                    TempData["ErrorMessage"] = "Usuário não autenticado!";
                    return RedirectToAction("Login", "Login");
                }
                if (string.IsNullOrEmpty(name) || price <= 0 || quantity < 0)
                {
                    TempData["ErrorMessage"] = "Todos os campos são obrigatórios e devem ser válidos!";
                    return View();
                }

                var product = _productRepository.AddProduct(name, price, quantity, user.Id);

                if (product == null)
                {
                    TempData["ErrorMessage"] = "Erro ao adicionar produto!";
                    return View();
                }
                TempData["SuccessMessage"] = "Produto adicionado com sucesso!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao adicionar produto: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, float price, int quantity)
        {
            try
            {
                var user = _sectionRepository.SearchSection();
                if (user == null)
                {
                    TempData["ErrorMessage"] = "Usuário não autenticado!";
                    return RedirectToAction("Login", "Login");
                }
                if (string.IsNullOrEmpty(name) || price <= 0 || quantity < 0)
                {
                    TempData["ErrorMessage"] = "Todos os campos são obrigatórios e devem ser válidos!";
                    return View();
                }

                var product = _productRepository.UpdateProduct(id, name, price, quantity, user.Id);

                if (product == null)
                {
                    TempData["ErrorMessage"] = "Erro ao atualizar produto!";
                    return View();
                }
                TempData["SuccessMessage"] = "Produto atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao atualizar produto: " + ex.Message;
                return View();
            }
        }
    }
}
