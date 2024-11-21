using System.Security.Cryptography;
using System.Text;

namespace SGDM_CFE.UI.Resources
{
    public class Utilities
    {
        public static string ComputeSHA256Hash(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hashedPassword = new StringBuilder();
            for (int bit = 0; bit < bytes.Length; bit++)
            {
                hashedPassword.Append(bytes[bit].ToString("x2"));
            }
            return hashedPassword.ToString();
        }
    }

    public class Row(string field, object? value)
    {
        public string? Field = field;
        public object? Value = value;
    }
}