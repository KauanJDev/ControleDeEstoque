using ControleDeEstoque.Models;
using ControleDeEstoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ISectionRepository _sectionRepository;

        public LoginController(IUsersRepository usersRepository, ISectionRepository sectionRepository)
        {
            _usersRepository = usersRepository;
            _sectionRepository = sectionRepository;
        }
        public IActionResult Index()
        {
            if (_sectionRepository.SearchSection() != null)
            {
                TempData["ErrorMessage"] = "Você já está logado!";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }

        public IActionResult Logout()
        {
            _sectionRepository.DeleteSection();
            TempData["SuccessMessage"] = "Logout realizado com sucesso!";
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }

        [HttpPost]
        public IActionResult Register(UsersModel model)
        {

            try
            {
                var user = _usersRepository.Register(model.Name, model.Email, model.Password);
                TempData["SuccessMessage"] = "Usuário registrado com sucesso! Bem-vindo, " + user.Name;
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocorreu um erro ao tentar registrar o usuário: " + ex.Message;
                return RedirectToAction("Register");
            }
        }

        [HttpPost]
        public IActionResult Login(UsersModel model)
        {
            try
            {
                var user = _usersRepository.Login(model.Email, model.Password);
                _sectionRepository.AddSection(user);
                TempData["SuccessMessage"] = "Login realizado com sucesso! Bem-vindo, " + user.Name;
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao fazer login: " + ex.Message;
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            try
            {
                var user = _usersRepository.ResetPassword(model.Email, model.Password, model.NewPassword);
                TempData["SuccessMessage"] = "Senha redefinida com sucesso!";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao redefinir a senha: " + ex.Message;
                return RedirectToAction("ResetPassword");
            }
        }
    }
}
