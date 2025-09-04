using ControleDeEstoque.Models;
using ControleDeEstoque.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ControleDeEstoque.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IProductRepository _productRepository;


        public HomeController(ISectionRepository sectionRepository, IProductRepository productRepository)
        {
            _sectionRepository = sectionRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var user = _sectionRepository.SearchSection();

            if (user == null)
            {
                TempData["ErrorMessage"] = "Você precisa estar logado para acessar essa página.";
                return RedirectToAction("Index", "Login");
            }

            var dados = _productRepository.SearchAllProducts(user.Id);

            ViewBag.DadosJson = JsonConvert.SerializeObject(dados);

            ViewBag.Username = user.Name;
            return View();
        }
    }
}
