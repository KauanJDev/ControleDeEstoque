using System.Security.Cryptography;
using System.Text;

namespace ControleDeEstoque.Helper
{
    public static class Crypt
    {
        public static string Encrypt(this string text)
        {

            var hash = SHA1.Create();
            var encodedText = new ASCIIEncoding();
            var array = encodedText.GetBytes(text);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var b in array)
            {
                strHexa.Append(b.ToString("X2"));
            }

            return strHexa.ToString();
        }
    }
}
