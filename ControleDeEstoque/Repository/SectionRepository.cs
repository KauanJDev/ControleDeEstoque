using ControleDeEstoque.Models;
using Newtonsoft.Json;

namespace ControleDeEstoque.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SectionRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddSection(UsersModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContextAccessor.HttpContext.Session.SetString("UserId", value);
        }

        public void DeleteSection()
        {
            _httpContextAccessor.HttpContext.Session.Remove("UserId");
        }

        public UsersModel SearchSection()
        {
            string userSession = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userSession)) return null;
            return JsonConvert.DeserializeObject<UsersModel>(userSession);
        }
    }
}
