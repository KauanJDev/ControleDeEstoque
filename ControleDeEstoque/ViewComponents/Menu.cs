using ControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControleDeEstoque.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string session = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(session)) return Content(string.Empty);
            var user = JsonConvert.DeserializeObject<UsersModel>(session);
            return View(user);
        }
    }
}
