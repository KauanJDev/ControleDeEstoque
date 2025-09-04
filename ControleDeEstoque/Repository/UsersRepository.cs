using ControleDeEstoque.DataContext;
using ControleDeEstoque.Helper;
using ControleDeEstoque.Models;

namespace ControleDeEstoque.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ControleDeEstoque.DataContext.AppDbContext _context;
        public UsersRepository(ControleDeEstoque.DataContext.AppDbContext context)
        {
            _context = context;
        }

        public UsersModel Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new InvalidOperationException("All fields are required!");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password.Encrypt());

            if (user == null)
            {
                throw new InvalidOperationException("Invalid email or password!");
            }

            return user;
        }

        public UsersModel Register(string name, string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new InvalidOperationException("All fields are required!");
                }
                if (_context.Users.Any(u => u.Email == email))
                {
                    throw new InvalidOperationException("Email already registered!");
                }

                var user = new UsersModel
                {
                    Name = name,
                    Email = email,
                    Password = password.Encrypt()
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while registering the user: " + ex.Message);
            }
        }

        public UsersModel ResetPassword(string email, string password, string newPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(newPassword))
            {
                throw new InvalidOperationException("All fields are required!");
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password.Encrypt());
            if (user == null)
            {
                throw new InvalidOperationException("Invalid email or password!");
            }
            user.Password = newPassword.Encrypt();
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
