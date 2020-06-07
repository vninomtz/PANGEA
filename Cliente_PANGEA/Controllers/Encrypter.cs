using System.Text;
using System.Security.Cryptography;

namespace Cliente_PANGEA.Controllers
{
    public static class Encrypter
    {
        /// <summary>
        /// Realiza un hash en una cadena de tipo SHA512
        /// </summary>
        /// <param name="originalPassword"> </param>
        /// <returns>devuelve la cadena cifrada </returns>
        public static string EncodePassword(string originalPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(originalPassword);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }

        }
    }
}
